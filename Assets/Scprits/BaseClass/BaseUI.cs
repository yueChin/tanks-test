using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI {

    protected GameFacade mFacade;

    public GameObject mRootUI;
    public bool IsHideComplete;
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }
    public virtual void Update() { }
    public virtual void Release() { }

    public virtual void Hide()
    {
        Image image = null;
        if (image == null)
        {
            image = mRootUI.GetComponent<Image>();
        }
        float alpha = image.color.a;
        alpha -= Time.deltaTime;
        if (alpha <= 0)
        {
            mRootUI.SetActive(false);
        }
    }

    public virtual void Show()
    {
        Image image = null;
        if (image == null)
        {
            image = mRootUI.GetComponent<Image>();
        }
        float alpha = image.color.a;
        alpha += Time.deltaTime;
        if (alpha >= 255)
        {
            mRootUI.SetActive(true);
        }
    }
    /*
    protected void Show()
    {
        mRootUI.SetActive(true);
    }
    protected void Hide()
    {
        mRootUI.SetActive(false);
    }
    */
}
