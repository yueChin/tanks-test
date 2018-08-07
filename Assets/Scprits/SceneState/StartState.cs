using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;
using UnityEngine;

public class StartState:SceneState
{
    public StartState(SceneStateController controller) : base("01StartScene", controller) { }


    public override void StateStart()
    {
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }
    private void OnStartButtonClick()
    {
        mController.SetState(new BattleState(mController));
    }
}

