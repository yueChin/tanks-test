using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : BaseUI
{
    private GameObject canvas;
    private GameObject mPanel;
    private Button mSingleBattle;
    private Button mDoubleFight;
    private Button mNetLink;
    private Button mQuit;
    private Image mImage;
    public override void Init()
    {
        base.Init();
        canvas = GameObject.Find("MainCanvas");
        mPanel = GameObject.Find("Panel");
        mSingleBattle = UITool.FindChild<Button>(mPanel, "Button_Single");
        mSingleBattle.onClick.AddListener(OnSingleButtonClickOn);
        mDoubleFight = UITool.FindChild<Button>(mPanel, "Button_Double");
        mDoubleFight.onClick.AddListener(OnDoubleButtonClickOn);
        mNetLink = UITool.FindChild<Button>(mPanel, "Button_NetLink");
        mDoubleFight.onClick.AddListener(OnNetButtonClickOn);
        //mQuit = UITool.FindChild<Button>(canvas, "Button_Exit");
        mImage = canvas.GetComponent<Image>();
        canvas.GetComponent<Canvas>().sortingOrder = 1;
    }

    public override void Release()
    {
        base.Release();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Hide()
    {
        if (mImage == null)
        {
            mImage = canvas.GetComponent<Image>();
        }
        //float alpha = image.color.a;
        //alpha -= Time.deltaTime;
        mImage.color = mImage.color = UITool.ChangeColor(mImage.color, 256, 256, 256, 0,0.1f);
        if (mImage.color.a <= 0)
        {
            IsHideComplete = true;
            //canvas.GetComponent<Canvas>().sortingOrder = 0;
            canvas.SetActive(false);
        }
    }

    public override void Show()
    {
        Debug.Log(canvas);
        if (!canvas.activeSelf)
        {
            Debug.Log(canvas);
            canvas.SetActive(true);
            //canvas.GetComponent<Canvas>().sortingOrder = 1;
        }
        IsHideComplete = false;
        if (mImage == null)
        {
            mImage = canvas.GetComponent<Image>();
        }
        //float alpha = mImage.color.a;
        //alpha += Time.deltaTime;
        mImage.color = UITool.ChangeColor(mImage.color, 256, 256, 256, 255, 0.1f);
    }

    public void OnSingleButtonClickOn()
    {
        UISystem.Instance.UIChange(WhichScene.SingleFight);
    }

    public void OnDoubleButtonClickOn()
    {
        UISystem.Instance.UIChange(WhichScene.DoubleBattle);
    }

    public void OnNetButtonClickOn()
    {
        UISystem.Instance.UIChange(WhichScene.NetLink);
    }
}
