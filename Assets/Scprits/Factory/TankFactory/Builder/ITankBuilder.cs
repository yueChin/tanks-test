using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITankBuilder {

    void AddTankAttr();
    void AddGameObject();
    void AddTurret();
    void AddInTankSystem();
    void AddMonoBehavour();
    void AddFlag();
    Tank GetResult();
}
