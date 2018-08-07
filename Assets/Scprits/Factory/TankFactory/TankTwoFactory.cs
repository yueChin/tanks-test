using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTwoFactory : ITankFactory {

    public Tank CreateTank<T>(TurretType turretType, Transform spawnPosition) where T : Tank, new()
    {
        Tank tank = new T();

        ITankBuilder builder = new TankTwoBuilder(tank, typeof(T), turretType, spawnPosition);

        return TankBuilderDirector.Construct(builder);
    }
}
