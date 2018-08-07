using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour {

    private Bullet mBullet;
    private AudioSource mAudioSource;
    private AudioClip mCharging;
    private Rigidbody mRigidbody;
    private Collider mCollider;
    private float mDestroyTime;

    public void SetCollider(Bullet bullet) {       
        mBullet = bullet;
    }

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        mCharging = FactoryManager.assetFactory.LoadAudioClip(AudioType.BulletCharging.ToString());
        mAudioSource.clip = mCharging;
        mRigidbody = GetComponent<Rigidbody>();
        mCollider = GetComponent<Collider>();
    }

    public void Init()
    {
        mDestroyTime = 0;
    }

    private void FixedUpdate()
    {
        if (mRigidbody.velocity.magnitude > 50f)
        {
            if (mCollider.enabled)
            {
                mCollider.enabled = false;
            }
            RaycastHit raycastHit;
            bool hit = Physics.Raycast(transform.position, transform.forward, out raycastHit, 5f);
            if (hit)
            {
                if (raycastHit.transform.tag == "Tank")
                {
                    int collider = raycastHit.transform.gameObject.GetHashCode();
                    GameFacade.Instance.HurtTank(collider, mBullet.Damage);
                }
                BulletExplosionFeature();
                BulletDestroy();
            }
        }
        else
        {
            if (!mCollider.enabled)
            {
                mCollider.enabled = true ;
            }
        }
    }

    private void Update()
    {
        if (!mAudioSource.isPlaying)
        {
            mAudioSource.Play();
        }
        mDestroyTime += Time.deltaTime;
        if (mDestroyTime > 25)
        {
            BulletDestroy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "Tank")
        {
            int collider = other.gameObject.GetHashCode();
            GameFacade.Instance.HurtTank(collider, mBullet.Damage);         
        }
        BulletExplosionFeature();
        BulletDestroy();
    }

    /// <summary>
    /// 特效碰撞功能函数
    /// </summary>
    /// <param name="bulletType"></param>
    /// <param name="effect"></param>
    /// <param name="bullet"></param>
    private void EffectCollider(BulletType bulletType,Effect effect,Bullet bullet)
    {
        if (bulletType == BulletType.Missile)
        {
            effect.gameObject.AddComponent<EffectCollider>().SetCollider(mBullet);
        }        
    }

    /// <summary>
    /// 子弹爆炸特效
    /// </summary>
    private void BulletExplosionFeature()
    {
        AudiosPoolManager.PointFixedAudio(mBullet.ExplosionAudio.ToString(), gameObject.transform.position, 0.25f);
        Effect effect = EffectsPoolManager.PointFixedEffect(mBullet.ExplosionEffect.ToString(), gameObject.transform.position, mBullet.Size);
        EffectCollider(mBullet.BulletType, effect, mBullet);
    }

    /// <summary>
    /// 销毁子弹
    /// </summary>
    private void BulletDestroy()
    {
        GameFacade.Instance.RemoveBullet(mBullet.Owner);
        ObjectsPoolManager.DestroyActiveObject(mBullet.BulletType.ToString(), gameObject);
    }
}
