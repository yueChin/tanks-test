using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem :GameSystem {

    private static UISystem mInstance = new UISystem();
    public static UISystem instance { get { return mInstance; } }
    private ChooseUI mChooseUI;


    public override void Init()
    {
        mChooseUI = new ChooseUI();
        base.Init();
        mChooseUI.Init();
    }
    public override void Update()
    {
        base.Update();
        mChooseUI.Update();
    }
    public override void Release()
    {
        base.Release();
        mChooseUI.Release();
    }
}
