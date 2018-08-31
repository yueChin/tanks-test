using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class EndState:SceneState
{
    public EndState(SceneStateController controller) : base("03EndScene", controller) { }

    public override void StateStart()
    {
        //GameObject.Find("ReadyButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
        UISystem.Instance.Init();
    }

    public override void StateEnd()
    {
        UISystem.Instance.Release();
    }

    public override void StateUpdate()
    {
        if (UISystem.Instance.WhichScene == WhichScene.DoubleBattle)
        {
            mController.SetState(new EnhancedState(mController));
        }
        else if (UISystem.Instance.WhichScene == WhichScene.SingleFight)
        {
            mController.SetState(new BattleState(mController));
        }
        else if (UISystem.Instance.WhichScene == WhichScene.NetLink)
        {
            //todo
        }
        UISystem.Instance.Update();
    }

    private void OnStartButtonClick()
    {
        mController.SetState(new EnhancedState(mController));
    }
}
