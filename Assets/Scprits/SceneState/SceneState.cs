using System;
using System.Collections.Generic;
using System.Text;


public class SceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public SceneState(string sceneName,SceneStateController controller)
    {
        mSceneName = sceneName;
        mController = controller;
    }

    public string SceneName
    {
        get { return mSceneName; }
    }
    //每次进入到这个状态的时候调用
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
    public virtual void StateFixedUpdate() { }
}
