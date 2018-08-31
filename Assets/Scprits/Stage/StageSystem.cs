using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class StageSystem : GameSystem {

    private StageHandle mStageHandle;
    
    private List<Transform> mPosList = new List<Transform>();

    public override void Init()
    {
        base.Init();
        mStageHandle = new StageHandle();
        mStageHandle.Init();
        
    }

    public override void Update()
    {
        base.Update();
        mStageHandle.Update();
    }

    //public void MaxDistance(List<Tank> tanks1, List<Tank> tanks2)
    //{
    //    mStageHandle.MaxDistance(tanks1, tanks2);
    //}

}
