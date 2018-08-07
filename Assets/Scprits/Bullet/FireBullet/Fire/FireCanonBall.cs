using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCanonBall : FiredBullet,IFire
{
    private bool isFiring;
    public FireCanonBall(Transform _FireSpot, Bullet _Bullet) : base(_FireSpot,_Bullet) { }

    public override GameObject Fire()
    {          
        GameObject.transform.position = mFireSpot.position; //发射子弹的初始位置和角度
        GameObject.transform.rotation = mFireSpot.rotation;
        GameObject.GetComponent<Rigidbody>().velocity = GameObject.transform.forward * mBullet.Speed; // 设置子弹发射出的初速度  
        return null;
    }

}
