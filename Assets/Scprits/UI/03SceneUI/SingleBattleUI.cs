using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleBattleUI : BaseUI
{
    private GameObject canvas;
    private GameObject mPanel_DifficultChoose;
    private GameObject mPanel_MapChoose;
    private GameObject mPanel_MapShow;
    private GameObject mPanel_Other;
    private GameObject mPanel_BattleStart;
    private Button mBullet_Exit;
    private Button mBullet_Start;
    private ToggleGroup mToggleGroup_Difficult;
    private ToggleGroup mToggleGroup_Map;
    private IEnumerable<Toggle> mToggleDifficult;
    private IEnumerable<Toggle> mToggleMap;
    private Image mImage;
    public bool IsChangeDone = false;
    public override void Init()
    {
        base.Init();
        canvas = GameObject.Find("SingleCanvas");
        mBullet_Exit = UITool.FindChild<Button>(canvas, "Button_Exit");
        mBullet_Exit.onClick.AddListener(OnExitButtonClickOn);

        mPanel_DifficultChoose = UITool.FindOneOfAllChild(canvas,"Panel_DifficultChoose");
        mPanel_MapChoose = UITool.FindOneOfAllChild(canvas, "Panel_MapChoose");
        mPanel_MapShow = UITool.FindOneOfAllChild(canvas, "Panel_MapShow");
        mPanel_Other = UITool.FindOneOfAllChild(canvas, "Panel_Other");

        mPanel_BattleStart = UITool.FindOneOfAllChild(canvas, "Panel_BattleStart");
        mBullet_Start = UITool.FindChild<Button>(mPanel_BattleStart, "Button_BattleGO");
        mBullet_Exit.onClick.AddListener(OnGOButtonClickOn);

        mToggleGroup_Difficult = UITool.FindChild<ToggleGroup>(mPanel_DifficultChoose, "DifficultChoose");
        mToggleGroup_Map = UITool.FindChild<ToggleGroup>(mPanel_MapChoose, "MapChoose");
        mToggleDifficult = mToggleGroup_Difficult.ActiveToggles();
        mToggleMap = mToggleGroup_Map.ActiveToggles();
        mImage = canvas.GetComponent<Image>();
        canvas.SetActive(false);
        //canvas.GetComponent<Canvas>().sortingOrder = 0;
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
        //float alpha = mImage.color.a;
        //alpha -= Time.deltaTime;
        mImage.color = UITool.ChangeColor(mImage.color, 256, 256, 255, 0, 0.1f);
        if (mImage.color.a <= 0)
        {
            IsHideComplete = true;
            //canvas.GetComponent<Canvas>().sortingOrder = 0;
            canvas.SetActive(false);
        }
    }

    public override void Show()
    {
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

    public void OnExitButtonClickOn()
    {
        UISystem.Instance.UIChange(WhichScene.MainTitle);
    }

    public void OnGOButtonClickOn()
    {
        UISystem.Instance.SingleBattle();
    }
}
