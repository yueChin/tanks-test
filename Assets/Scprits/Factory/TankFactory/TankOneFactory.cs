using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankOneFactory : ITankFactory
{

    public Tank CreateTank<T>(TurretType TurretType, Transform spawnPosition) where T : Tank, new()
    {
        Tank tank = new T();
        ITankBuilder builder = new TankOneBuilder(tank, typeof(T), TurretType, spawnPosition);
        
        return TankBuilderDirector.Construct(builder);
    }
}
