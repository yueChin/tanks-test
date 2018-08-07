using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class StageHandle
{
    private List<Transform> mSpawnPositons = new List<Transform>();
    private GameObject mMainCamera;
    private Camera mCamera;
    private Vector3 mOffset;
    private Transform mFollowOne;
    private Transform mFollowTwo;
    private TurretType mType1 = TurretType.ShellTurret;
    private TurretType mType2 = TurretType.ShellTurret;

    public void Init()
    {
        LoadSave();
        InitPosition();
        InitStage();
        InitView();
    }

    public void Update()
    {
        UpdateView();
    }

    private void LoadSave()
    {
        string filePath = Application.dataPath + "/StreamingFile" + "/Json.json";
        if (File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath); //创建一个StreamReader
            string jsonStr = sr.ReadToEnd(); //将读取到的流赋值给jsonStr
            sr.Close(); //关闭流
            ChooseSave save = JsonMapper.ToObject<ChooseSave>(jsonStr);       //将字符串jsonStr转换为Save对象      
            Debug.Log("Load OJ8K");
            mType1 = save.turretType1;
            mType2 = save.turretType2;
        }
        else
        {
            Debug.Log("存档文件不存在");
        }
    }

    private void InitPosition()
    {
        int i = 1;
        while (true)
        {
            GameObject go = GameObject.Find("Spawn" + i);
            if (go != null)
            {
                mSpawnPositons.Add(go.transform);
                i++;
            }
            else
            {
                break;
            }
        }
    }

    private void InitStage()
    {
        GameFacade.Instance.MaxDistance();
        mMainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource audioSource = mMainCamera.AddComponent<AudioSource>();
        audioSource.clip = FactoryManager.assetFactory.LoadAudioClip("BackgroundMusic");
        audioSource.loop = true;
        audioSource.volume = 0.4f;
        audioSource.Play();
        SpawnOne(mType1);
        SpawnTwo(mType2);
    }

    private void SpawnOne(TurretType _tt)
    {
        FactoryManager.OneFactory.CreateTank<Tank1>(_tt, GetPos());
    }

    private void SpawnTwo(TurretType _tt)
    {
        FactoryManager.TwoFactory.CreateTank<Tank2>(_tt, GetPos());
    }

    private Transform GetPos()
    {
        return mSpawnPositons[UnityEngine.Random.Range(0, mSpawnPositons.Count)];
    }
    
    public void MaxDistance(List<Tank> tanks1, List<Tank> tanks2)
    {
        float tempDistance = 0;
        Transform tempFollow1 = null;
        Transform tempFollow2 = null;
        if (tanks1 == null || tanks2 == null) return;
        foreach (Tank1 t1 in tanks1)
        {
            foreach (Tank2 t2 in tanks2)
            {
                if (Vector3.Distance(t1.Position, t2.Position) > tempDistance)
                {
                    tempFollow1 = t1.GameObject.transform;
                    tempFollow2 = t2.GameObject.transform;
                    tempDistance = Vector3.Distance(t1.Position, t2.Position);
                }
            }
        }
        mFollowOne = tempFollow1;
        mFollowTwo = tempFollow2;
    }

    private void InitView()
    {        
        mOffset = mMainCamera.transform.position + (mFollowOne.position + mFollowTwo.position) / 2;
        mCamera = mMainCamera.GetComponent<Camera>();
    }

    private void UpdateView()
    {
        GameFacade.Instance.MaxDistance();
        if (mFollowOne == null || mFollowTwo == null) return;
        mMainCamera.transform.position = (mFollowOne.position + mFollowTwo.position) / 2 + new Vector3(0, 70, -25);
        float distance = Vector3.Distance(mFollowOne.position, mFollowTwo.position);
        float size = distance * 0.68f;
        if (size > 6)
        {
            mCamera.orthographicSize = size;
        }
        else
        {
            size = 6;
        }
    }
}
