using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnhancedState : SceneState
{
    public EnhancedState(SceneStateController controller):base("04EnhancedScene",controller)
    {}

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }

    public override void StateFixedUpdate()
    {
        if (GameFacade.Instance.GameOver)
        {
            StateUpdate();
        }
        GameFacade.Instance.FixedUpdate();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.GameOver)
        {
            mController.SetState(new EndState(mController));
        }
        GameFacade.Instance.Update();
    }

    public override void StateLateUpdate()
    {
        if (GameFacade.Instance.GameOver)
        {
            StateUpdate();
        }
        GameFacade.Instance.LateUpdate();
    }
}

