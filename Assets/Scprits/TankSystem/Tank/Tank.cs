using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tank
{       
    private AudioClip mEngingIdle;
    private AudioClip mEngineDriving;
    private float mVertical;
    private float mHorizontal;
    private Tank mTempTarget;

    protected AudioSource mAudioSource;
    protected AudioClip mTankExplosion;
    protected TankAttr mAttr;
    protected GameObject mAnyTank;    
    protected Turret mTurret;
    protected BoxCollider mBoxCollider;
    protected Tank mTarget;
    protected Rigidbody mRigidbody;
    protected Slider mSlider;

    protected bool mIsKilled = false;
    protected bool mCanDestroy = false;
    protected float mDestroyTimer = 0.3f;
    protected float mSearchDistance = 12;

    public Vector3 Position //坦克当前位置
    {
        get
        {
            if (mAnyTank == null)
            {
                Debug.LogError("mAnyTank为空"); return Vector3.zero;
            }
            return mAnyTank.transform.position;
        }
    }
    public TankAttr Attr { set { mAttr = value; } get { return mAttr; } }
    public bool CanDestroy { get { return mCanDestroy; } }
    public bool IsKilled { get { return mIsKilled; } }
    public Tank Target { get { return mTarget; }set { mTarget = value; } }

    public GameObject GameObject
    {
        set
        {
            mAnyTank = value;
            mRigidbody = mAnyTank.GetComponent<Rigidbody>();
        }
        get
        {
            return mAnyTank;
        }
    }

    //设置什么样的炮台
    public Turret Turret
    {
        set
        {
            mTurret = value;
            mTurret.Owner = this;
            GameObject child = UnityTool.FindOneOfActiveChild(mAnyTank, "TankTurret"); //在底座上建立炮塔
            UnityTool.Attach(child, mTurret.AnyTuret);
        }
        get
        {
            return mTurret;
        }
    }

    public void Init() {
        mSlider = GameObject.GetComponentInChildren<Slider>();
        mSlider.value = (float)Attr.CurrentHP / Attr.TotalHP;
        mAudioSource = GameObject.GetComponent<AudioSource>();
        mEngineDriving = FactoryManager.assetFactory.LoadAudioClip(AudioType.EngineDriving.ToString());
        mEngingIdle = FactoryManager.assetFactory.LoadAudioClip(AudioType.EngineIdle.ToString());
        mTankExplosion = FactoryManager.assetFactory.LoadAudioClip("TankExplosion");
        mTurret.Init();
    }

    public void FixedUpdate()
    {
        mVertical = Input.GetAxis("VerticalPlayer" + mAttr.PlayerNumBer);
        mHorizontal = Input.GetAxis("HorizontalPlayer" + mAttr.PlayerNumBer);
        mRigidbody.velocity = mAnyTank.transform.forward * mVertical * mAttr.MoveSpeed;
        mRigidbody.angularVelocity = mAnyTank.transform.up * mHorizontal * mAttr.RotateSpeed;
        if (Mathf.Abs(mHorizontal) < 0.1 || Mathf.Abs(mVertical) < 0.1) //移动或者停止时发出何种声音
        {
            mAudioSource.clip = mEngingIdle;
            if (mAudioSource.isPlaying == false)
            {
                mAudioSource.Play();
            }
        }
        else
        {
            mAudioSource.clip = mEngineDriving;
            if (mAudioSource.isPlaying == false)
            {
                mAudioSource.Play();
            }
        }
    }

    public virtual void Update()
    {        
        if (mIsKilled)
        {
            mDestroyTimer -= Time.deltaTime;
            if (mDestroyTimer <= 0) //播放完特效后，销毁
            {
                mCanDestroy = true;
            }
            return;
        }
        mTurret.Update();
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.TakeDamage(damage);
    }

    public virtual void Killed()
    {
        mIsKilled = true;
    }

    public void Release()
    {
        ObjectsPoolManager.DestroyActiveObject(mAttr.PrefabName.ToString(),mAnyTank);
        //GameObject.Destroy(mAnyTank);
    }

    public void Search(List<Tank> targets) //返回一个最近tank目标
    {        
        if (targets == null || targets.Count == 0) //如果没有敌对目标了，返回
        {
            mTempTarget = null;
            return;
        }
        float tempDistance = mSearchDistance;
        foreach (Tank t in targets)
        {
            float nowDis = Vector3.Distance(t.Position, Position);
            if (nowDis > mSearchDistance) //如果目标超出范围
            {
                mTempTarget = null;
            }            
            if (nowDis < tempDistance)//如果目标在搜索范围内，并且小于上一个tank的距离,重置最小距离和最近目标
            {
                tempDistance = nowDis;
                mTempTarget = t;
            }
        }
        Target = mTempTarget; //设置坦克的最近目标
    }
}
