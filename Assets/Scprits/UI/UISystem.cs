using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WhichScene{
    MainTitle,
    DoubleBattle,
    SingleFight,
    NetLink
}

public class UISystem :GameSystem {

    private static UISystem mInstance = new UISystem();
    public static UISystem Instance { get { return mInstance; } }
    private MainUI mMainUI;
    private DoubleFightUI mDoubleFightUI;
    private SingleBattleUI mSingleBalletUI;
    private BaseUI mCurrentUI;
    private BaseUI mTargetUI;
    private bool IsChanging;

    private WhichScene mWhichScene;
    public WhichScene WhichScene { get { return mWhichScene; } }
    public override void Init()
    {
        mMainUI = new MainUI();
        mDoubleFightUI = new DoubleFightUI();
        mSingleBalletUI = new SingleBattleUI();

        base.Init();
        mTargetUI = mMainUI;
        mMainUI.Init();
        mDoubleFightUI.Init();
        mSingleBalletUI.Init();
        mWhichScene = WhichScene.MainTitle;
        mCurrentUI = mMainUI;
    }

    public override void Update()
    {
        base.Update();
        mCurrentUI.Update();
        if (IsChanging)
        {
            ChangeUI();
        }
    }

    public override void Release()
    {
        base.Release();
        mCurrentUI.Release();
    }

    public void UIChange(WhichScene whichScene)
    {
        IsChanging = true;
        if (whichScene == WhichScene.DoubleBattle)
        {
            mTargetUI = mDoubleFightUI;
        }
        else if (whichScene == WhichScene.SingleFight)
        {
            mTargetUI = mSingleBalletUI;
        }
        else if (whichScene == WhichScene.MainTitle)
        {
            mTargetUI = mMainUI;
        }
          
    }

    public void ChangeUI()
    {
        //Debug.Log(mTargetUI);
        //Debug.Log(mCurrentUI.IsHideComplete);
        if (mCurrentUI.IsHideComplete)
        {
            mCurrentUI = mTargetUI;
            mCurrentUI.Show();
            IsChanging = false;
            return;
        }
        mCurrentUI.Hide();
    }

    public void SingleBattle()
    {
        mWhichScene = WhichScene.SingleFight;
    }

    public void DoubleFight()
    {
        mWhichScene = WhichScene.DoubleBattle;
    }

}
