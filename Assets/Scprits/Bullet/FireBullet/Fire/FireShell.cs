using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class FireShell: FiredBullet,IFire{

    public FireShell(Transform _FireSpot,Bullet _Bullet) : base(_FireSpot,_Bullet) {}

    public override GameObject Fire()
    {
        GameObject.transform.localScale = mFireSpot.localScale * mBullet.Size;  // 设置要实例化的子弹大小
        GameObject.transform.position = mFireSpot.position; //发射子弹的初始位置和角度
        GameObject.transform.rotation = mFireSpot.rotation;
        GameObject.GetComponent<Rigidbody>().velocity = GameObject.transform.forward * mBullet.Speed; // 设置子弹发射出的初速度
        return null;
    }
}
