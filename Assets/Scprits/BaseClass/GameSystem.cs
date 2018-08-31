using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameSystem {

    protected GameFacade mFacade;
    public virtual void Init()
    {
        mFacade = GameFacade.Instance;
    }

    public virtual void FixedUpdate() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }
    public virtual void Release() { }
}
