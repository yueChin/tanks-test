using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTwoBuilder :TankBuilder,ITankBuilder {

    public TankTwoBuilder(Tank tank, System.Type t, TurretType turretType,Transform spawnPosition)
        : base(tank, t, turretType, spawnPosition)
    { }
    public void AddTankAttr()
    {
        TankAttr tankAttr = FactoryManager.attrFactory.GetTankAttr(mT);
        mPrefabName = tankAttr.PrefabName;
        mTank.Attr = tankAttr;
    }

    public void AddGameObject()
    {
        GameObject GO = FactoryManager.assetFactory.LoadTankTwo(mPrefabName);
        GO.transform.position = mSpawnPosition.position;
        GO.transform.rotation = mSpawnPosition.rotation;
        mTank.GameObject = GO;
    }

    public void AddTurret()
    {
        Turret Turret = FactoryManager.TurretFactory.CreateTurret(mTurretType);
        Transform turretTransform = UnityTool.FindOneOfActiveChild(mTank.GameObject, "TankTurret").transform;
        mTank.Turret = Turret;
        mTank.Turret.AnyTuret.transform.position = turretTransform.position;
    }

    public Tank GetResult()
    {
        return mTank;
    }

    public void AddMonoBehavour()
    {
        
    }

    public void AddInTankSystem()
    {
        GameFacade.Instance.AddTankTwo(mTank as Tank2);
        ObjectsPoolManager.PushObject(mPrefabName,mTank.GameObject);
    }

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
        Material material = FactoryManager.assetFactory.LoadMaterial("Red");
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
