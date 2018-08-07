using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretFactory
{
    Turret CreateTurret(TurretType turretType);
}
