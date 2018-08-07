using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet{
    protected GameObject mAnyBullet; //子弹预制件    
    protected BulletCurrentAttr mBulletCurrentAttr;
    protected BulletFeature mBulletFeature;
    protected FiredBullet mOwner;

    public FiredBullet Owner
    {
        set { mOwner = value; }
        get { return mOwner; }
    }
    
    public float Damage { get { return mBulletCurrentAttr.Damage; } }     //供外部读取的伤害
    public float Size { get {return mBulletCurrentAttr.Size; } }         // 供外部读取的大小
    public float Speed { get { return mBulletCurrentAttr.Speed; } }       //供外部读取的速度
    public GameObject AnyBullet { set { mAnyBullet = value; } get { return mAnyBullet; } }  //供外部读取的子弹物体
    public BulletFeature BulletFeature { set { mBulletFeature = value; } }
    public BulletType BulletType { get { return mBulletFeature.BulletType; } } //供外部读取的子弹类型
    public AudioType ExplosionAudio { get { return mBulletFeature.ExplosionAudio; } }
    public EffectType ExplosionEffect { get { return mBulletFeature.ExplosionEffect; } }
    
    public void SetBulletAttr(float holdTime) {
        mBulletCurrentAttr = new BulletCurrentAttr(holdTime);
    }

}
