using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttr  {

    protected KeyCode mFirekey;
    protected float mMoveSpeed;
    protected float mRotateSpeed;
    protected int mTotalHP;
    protected int mCurrentHP;
    protected string mPrefabName;
    protected int mPlayerNumber = 1;
    

    public TankAttr(int _HP, float _MoveSpeed, float _RotateSpeed, KeyCode _KeyCode,string _PrefabName,int _PlayerNumber)
    {
        mTotalHP = _HP;
        mCurrentHP = mTotalHP;
        mMoveSpeed = _MoveSpeed;
        mRotateSpeed = _RotateSpeed;
        mFirekey = _KeyCode;
        mPrefabName = _PrefabName;
        mPlayerNumber = _PlayerNumber;
    }
    public KeyCode FireKey { get { return mFirekey; } }
    public float MoveSpeed { set { mMoveSpeed = value; } get { return mMoveSpeed; } }
    public float RotateSpeed { get { return mRotateSpeed; } }
    public int CurrentHP { get { return mCurrentHP; } }
    public int TotalHP { get { return mTotalHP; } }
    public string PrefabName { get { return mPrefabName; } }
    public int PlayerNumBer { get { return mPlayerNumber; } }

    public void TakeDamage(int damage)
    {
        mCurrentHP -= damage;
    }
}
