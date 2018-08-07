using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFactory : ITurretFactory
{
    public Turret CreateTurret(TurretType turretType)
    {
        Turret Turret = null;
        GameObject TurretGO = FactoryManager.assetFactory.LoadTurret(turretType.ToString());
        TurretAttr TurretAttr = FactoryManager.attrFactory.GetTurretAttr(turretType);
        switch (turretType)
        {
            case TurretType.ShellTurret:
                Turret = new TurretShell(TurretGO,TurretAttr);
                break;
            case TurretType.MissileLauncher:
                Turret = new TurretMissile(TurretGO,TurretAttr);
                break;
            case TurretType.LaserBeamer:
                Turret = new TurretLaser(TurretGO,TurretAttr);
                break;
            case TurretType.CanonTurret:
                Turret = new TurretCanon(TurretGO,TurretAttr);
                break;
        }
        return Turret;
    }
}