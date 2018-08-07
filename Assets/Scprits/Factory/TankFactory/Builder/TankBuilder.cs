using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBuilder {

    protected Tank mTank;
    protected System.Type mT;
    protected TurretType mTurretType;
    protected Transform mSpawnPosition;
    protected string mPrefabName = "";

    public TankBuilder(Tank tank, System.Type t, TurretType turretType, Transform spawnPosition )
    {
        mTank = tank;
        mT = t;
        mTurretType = turretType;
        mSpawnPosition = spawnPosition;
    }
}
