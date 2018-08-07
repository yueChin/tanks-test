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
        GameObject.Find("ReadyButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
        UISystem.instance.Init();
    }
    public override void StateEnd()
    {
        UISystem.instance.Release();
    }
    public override void StateUpdate()
    {
        UISystem.instance.Update();
    }
    private void OnStartButtonClick()
    {
        mController.SetState(new EnhancedState(mController));
    }
}
