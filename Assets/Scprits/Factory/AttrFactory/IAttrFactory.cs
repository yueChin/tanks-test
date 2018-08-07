using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrFactory {

    TankAttr GetTankAttr(System.Type t);
    TurretAttr GetTurretAttr(TurretType turretType);
    BulletFeature GetBulletFeature(TurretType bulletType);
}
