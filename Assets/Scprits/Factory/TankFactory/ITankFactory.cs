using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITankFactory  {

    Tank CreateTank<T>(TurretType turretType, Transform spawnPosition) where T : Tank, new();
}
