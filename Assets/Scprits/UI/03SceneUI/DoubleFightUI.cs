using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System;

public class DoubleFightUI : BaseUI
{
    private GameObject canvas;
    private GameObject mPanel;
    private GameObject mPlayer1;
    private GameObject mPlayer2;
    private List<GameObject> play1;
    private List<GameObject> play2;
    private ToggleGroup mToggleGroup1;
    private ToggleGroup mToggleGroup2;
    private IEnumerable<Toggle> anyToggle1;
    private IEnumerable<Toggle> anyToggle2;

    private string mWhichToggle1;
    private string mWhichToggle2;

    private GameObject mTemp;
    private Button mButton_Exit;
    private Button mButton_Ready;
    private Image mImage;
    public override void Init()
    {
        base.Init();
        //GameObject canvas = UITool.GetCanvas(); //得到主画布
        canvas = GameObject.Find("DoubleCanvas");
        mPanel = UITool.FindOneOfAllChild(canvas, "Panel");
        mPlayer1 = UITool.FindOneOfAllChild(canvas, "Player1");
        mPlayer2 = UITool.FindOneOfAllChild(canvas, "Player2");
        mToggleGroup1 = UITool.FindChild<ToggleGroup>(mPanel, "Player1WhichTurret");
        mToggleGroup2 = UITool.FindChild<ToggleGroup>(mPanel, "Player2WhichTurret");
        anyToggle1 = mToggleGroup1.ActiveToggles();
        anyToggle2 = mToggleGroup2.ActiveToggles();
        play1 = UnityTool.FindAllChild(mPlayer1);
        //Debug.Log(play1);
        //Debug.Log(play1.Count);
        play2 = UnityTool.FindAllChild(mPlayer2);
        mButton_Exit = UITool.FindChild<Button>(canvas,"Button_Exit");
        mButton_Exit.onClick.AddListener(OnExitButtonClickOn);
        mButton_Ready = UITool.FindChild<Button>(mPanel, "ReadyButton");
        mButton_Ready.onClick.AddListener(OnReadyButtonClickOn);
        mImage = canvas.GetComponent<Image>();
        canvas.SetActive(false);
        //canvas.GetComponent<Canvas>().sortingOrder = 0;
    }

    public override void Update()
    {
        base.Update();
        for (int i = 0; i < play1.Count;i++)
        {
            foreach (Toggle t in anyToggle1)
            {
                if (play1[i].name == t.name)
                {
                    play1[i].SetActive(true);
                }
                else
                {
                    play1[i].SetActive(false);
                }

            }
        }
        for (int i = 0; i < play2.Count; i++)
        {
            foreach (Toggle t in anyToggle2)
            {
                if (play2[i].name == t.name)
                {
                    play2[i].SetActive(true);
                }
                else
                {
                    play2[i].SetActive(false);
                }

            }
        }
        /*
        foreach (GameObject go in play1)
        {
            foreach (Toggle t in anyToggle1)
            {
                if (go.name == t.name)
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }

            }
        }
        foreach (GameObject go in play2)
        {
            foreach (Toggle t in anyToggle2)
            {
                if (go.name == t.name)
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }

            }
        }
        */
    }

    public override void Release()
    {
        base.Release();
        foreach (Toggle t in anyToggle1)
        {
            if (t.isOn)
            {
                mWhichToggle1 = t.name;
            }

        }
        foreach (Toggle t in anyToggle2)
        {
            if (t.isOn)
            {
                mWhichToggle2 = t.name;
            }
        }
        SaveJson();
        return;
    }

    private void SaveJson()
    {        
        ChooseSave save = new ChooseSave();
        foreach (TurretType tt in Enum.GetValues(typeof(TurretType)) ) {
            if (tt.ToString() == mWhichToggle1) {
                save.turretType1 = tt;
            }
            if (tt.ToString() == mWhichToggle2)
            {
                save.turretType2 = tt;
            }
        }
        string filePath = Application.dataPath + "/StreamingFile" + "/Json.json";
        //利用JsonMapper将save对象转换为Json格式的字符串
        string saveJsonStr = JsonMapper.ToJson(save);
        //将这个字符串写入到文件中
        //创建一个StreamWriter，并将字符串写入文件中
        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(saveJsonStr);
        //关闭StreamWriter
        sw.Close();
        Debug.Log("保存成功");
    }

    public void OnExitButtonClickOn()
    {
        UISystem.Instance.UIChange(WhichScene.MainTitle);
    }

    public void OnReadyButtonClickOn()
    {
        UISystem.Instance.DoubleFight();
    }

    public override void Hide()
    {
        Debug.Log("hide");
        if (mImage == null)
        {
            mImage = canvas.GetComponent<Image>();
        }
        //float alpha = image.color.a;
        mImage.color = UITool.ChangeColor(mImage.color,256, 256, 256, 0,0.1f);
        if (mImage.color.a <= 0)
        {
            IsHideComplete = true;
            canvas.SetActive(false);
            //canvas.GetComponent<Canvas>().sortingOrder = 0;
        }
    }

    public override void Show()
    {
        Debug.Log(canvas);
        if (!canvas.activeSelf)
        {
            Debug.Log(canvas);
            canvas.SetActive(true);
            Debug.Log(canvas);
            //canvas.GetComponent<Canvas>().sortingOrder = 1;
        }
        IsHideComplete = false;
        if (mImage == null)
        {
            mImage = canvas.GetComponent<Image>();
        }
        //float alpha = image.color.a;
        //alpha += Time.deltaTime;
        mImage.color = UITool.ChangeColor(mImage.color, 256, 256, 256, 255,0.1f);
    }
}
