using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd  {

	public static BattleEnd Instance { get { return mInstance; } }
    private static BattleEnd mInstance = new BattleEnd() { mIsEnd =false };

    public bool IsBattleEnd { get { return mIsBattleEnd; } }
    public bool IsEnd { get { return mIsEnd; } }
    private bool mIsEnd;
    private bool mIsBattleEnd;

    public void Update()
    {

    }

    public void GameIsOver()
    {
        mIsEnd = true;
    }

    
}
