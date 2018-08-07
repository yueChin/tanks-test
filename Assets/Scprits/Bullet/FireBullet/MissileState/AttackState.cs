using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState :MissileState,IMissileState {

    public AttackState(MissileStateController missileStateController, FireMissile fireMissile) : base(missileStateController, fireMissile)
    {
        Debug.Log("attack");
    }

    public void Act()
    {
        mRigidbody.AddForce(GameObject.transform.forward * 250, ForceMode.Impulse); //冲刺
    }

    public void Do()
    {
        
    }

    public void Reason()
    {
        
    }
}
