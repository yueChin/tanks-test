﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTwoAttr : TankAttr
{
    public TankTwoAttr(int _HP, float _MoveSpeed,float _RotateSpeed, KeyCode _KeyCode,string _PrefabName,int _PlayerNumber) 
        : base(_HP, _MoveSpeed, _RotateSpeed, _KeyCode,_PrefabName,_PlayerNumber) { }
}
