using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System;

public class ChooseUI : BaseUI {

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

    public override void Init()
    {
        base.Init();
        
        //GameObject canvas = UITool.GetCanvas(); //得到主画布
        GameObject canvas = GameObject.Find("Double");
        mRootUI = UnityTool.FindOneOfActiveChild(canvas, "Panel"); //得到Panel
        mPlayer1 = UnityTool.FindOneOfActiveChild(canvas, "Player1");
        mPlayer2 = UnityTool.FindOneOfActiveChild(canvas, "Player2");
        mToggleGroup1 = UITool.FindChild<ToggleGroup>(mRootUI, "Player1WhichTurret");
        mToggleGroup2 = UITool.FindChild<ToggleGroup>(mRootUI, "Player2WhichTurret");

        anyToggle1 = mToggleGroup1.ActiveToggles();
        anyToggle2 = mToggleGroup2.ActiveToggles();
        play1 = UnityTool.FindAllChild(mPlayer1);
        play2 = UnityTool.FindAllChild(mPlayer2);
    }

    public override void Update()
    {
        base.Update();
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
    
}
