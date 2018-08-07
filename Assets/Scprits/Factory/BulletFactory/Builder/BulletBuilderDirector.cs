using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderBuilderDirector  {

    public static Bullet Construct(IBulletBuilder builder)
    {
        builder.AddBulletFeature();
        builder.AddGameObject();
        builder.AddBulletAttr();
        builder.AddMonoBehavior();
        return builder.GetResult();
    }
}
