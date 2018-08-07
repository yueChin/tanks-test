using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BattleState:SceneState
{
    public BattleState(SceneStateController controller):base("02BattleScene",controller)
    {}

    public override void StateUpdate()
    {
        if (BattleEnd.Instance.IsEnd)
        {
            mController.SetState(new EndState(mController));
        }
        BattleEnd.Instance.Update();
    }
}

