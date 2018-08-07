using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileStateController  {

    private IMissileState mCurrentState;
    public IMissileState currentState { get { return mCurrentState; } }

    public void SetState(IMissileState missileState)
    {
        mCurrentState = missileState;
    }

    public void FixedUpdateSate()
    {
        mCurrentState.Do();
    }

    public void UpdateSate()
    {
        mCurrentState.Act();
    }

}
