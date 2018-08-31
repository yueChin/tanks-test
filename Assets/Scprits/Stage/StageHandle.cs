using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class StageHandle
{
    private List<Transform> mSpawnPositons = new List<Transform>();


    private TurretType mType1 = TurretType.ShellTurret;
    private TurretType mType2 = TurretType.ShellTurret;

    public void Init()
    {
        LoadSave();
        InitPosition();
        InitStage();
        //InitView();
    }

    public void Update()
    {
        //UpdateView();
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
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource audioSource = mainCamera.AddComponent<AudioSource>();
        audioSource.clip = FactoryManager.assetFactory.LoadAudioClip("BackgroundMusic");
        audioSource.loop = true;
        audioSource.volume = 0.4f;
        audioSource.Play();
        SpawnOne(mType1);
        SpawnTwo(mType2);
        //GameFacade.Instance.MaxDistance();
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
    
    
}
