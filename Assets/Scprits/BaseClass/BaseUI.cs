using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI {

    protected GameFacade mFacade;

    public GameObject mRootUI;
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    protected void Show()
    {
        mRootUI.SetActive(true);
    }
    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
}
