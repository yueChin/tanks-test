using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletBuilder  {
    void AddGameObject();
    void AddBulletAttr();
    void AddBulletFeature();
    void AddMonoBehavior();
    Bullet GetResult();

}
