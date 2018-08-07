using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBuilderDirector  {
    /// <summary>
    /// 建筑模式指导者，返回的是一个ITank类，在坦克工厂里调用此方法
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static Tank Construct(ITankBuilder builder)
    {
        builder.AddTankAttr();
        builder.AddGameObject();                
        builder.AddTurret();
        builder.AddMonoBehavour();
        builder.AddFlag();
        builder.AddInTankSystem();
        
        return builder.GetResult();
    }
}
