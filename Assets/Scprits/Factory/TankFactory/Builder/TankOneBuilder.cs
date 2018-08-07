using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankOneBuilder : TankBuilder,ITankBuilder{

    public TankOneBuilder(Tank tank, System.Type t, TurretType turretType, Transform spawnPosition)
        : base(tank, t, turretType, spawnPosition)
    { }

    /// <summary>
    /// 添加坦克的属性，目前都是一样的
    /// </summary>
    public void AddTankAttr()
    {
        TankAttr tankAttr = FactoryManager.attrFactory.GetTankAttr(mT);
        mPrefabName = tankAttr.PrefabName;
        mTank.Attr = tankAttr;
    }

    /// <summary>
    /// 添加坦克底座
    /// </summary>
    public void AddGameObject() 
    {
        GameObject GO = FactoryManager.assetFactory.LoadTankOne(mPrefabName);
        GO.transform.position = mSpawnPosition.position;
        GO.transform.rotation = mSpawnPosition.rotation;
        mTank.GameObject = GO;
    }

    /// <summary>
    /// 添加坦克炮台
    /// </summary>
    public void AddTurret()
    {
        Turret Turret = FactoryManager.TurretFactory.CreateTurret(mTurretType); //实例化炮台
        Transform turretposition = UnityTool.FindOneOfActiveChild(mTank.GameObject, "TankTurret").transform; 
        //得到炮台挂载点位置
        mTank.Turret = Turret;
        mTank.Turret.AnyTuret.transform.position = turretposition.position;
    }

    /// <summary>
    ///  添加坦克需要的unity组件
    /// </summary>
    public void AddMonoBehavour()
    {
        
    }

    /// <summary>
    /// 返回一个完整的坦克
    /// </summary>
    /// <returns></returns>
    public Tank GetResult()
    {
        return mTank;
    }

    /// <summary>
    /// 在坦克系统里增加改生成的坦克
    /// </summary>
    public void AddInTankSystem()
    {        
        GameFacade.Instance.AddTankOne(mTank as Tank1);
        ObjectsPoolManager.PushObject(mPrefabName, mTank.GameObject);
    }

    /// <summary>
    /// 添加坦克标识
    /// </summary>
    public void AddFlag()
    {
        int number;
        GameObject go = UnityTool.FindOneOfActiveChild(mTank.Turret.AnyTuret, "Turret");
        if (mTurretType == TurretType.ShellTurret)
        {
            number = 0;
        }
        else
        {
            number = 1;
        }
        Material[] materialarry = go.GetComponent<Renderer>().materials;
        Material material = FactoryManager.assetFactory.LoadMaterial("Blue");
        for (int i = 0; i < materialarry.Length; i++)
        {
            if (i == number)
            {
                materialarry[i] = material;
            }
        }
        go.GetComponent<Renderer>().sharedMaterials = materialarry;
    }
}
