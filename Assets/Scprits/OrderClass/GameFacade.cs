using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade {
        
    public static GameFacade Instance { get { return mInstance; } }
    public bool GameOver { get { return mIsGameOver; } }
    private static GameFacade mInstance = new GameFacade() { mIsGameOver =false};
    private bool mIsGameOver = false;

    private TankSystem mTankSystem;
    private BulletSystem mBulletSystem;
    private StageSystem mStageSystem;

    public void Init()
    {
        mStageSystem = new StageSystem();
        mTankSystem = new TankSystem();
        mBulletSystem = new BulletSystem();
        
        mStageSystem.Init();
        mTankSystem.Init();
        mBulletSystem.Init();
    }

    public void FixedUpdate()
    {
        mTankSystem.FixedUpdate();
        mBulletSystem.FixedUpdate();
    }

    public void Update()
    {
        mTankSystem.Update();
        mBulletSystem.Update();
        mStageSystem.Update();
    }

    public void Release() {
        mTankSystem.Release();
        mBulletSystem.Release();
        mStageSystem.Release();
    }

    public void GameIsOver() {
        mIsGameOver = true;
    }

    public void AddTankOne(Tank1 tank)
    {
        mTankSystem.AddTankOne(tank);
    }

    public void AddTankTwo(Tank2 tank)
    {
        mTankSystem.AddTankTwo(tank);
    }

    public void RemoveTankOne(Tank1 tank)
    {
        mTankSystem.RemoveTankOne(tank);
    }

    public void RemoveTankTwo(Tank2 tank)
    {
        mTankSystem.RemoveTankTwo(tank);
    }

    public void AddBullet(FiredBullet firedBullet)
    {
        mBulletSystem.AddBulletSystem(firedBullet);
    }

    public void RemoveBullet(FiredBullet firedBullet)
    {
        mBulletSystem.RemoveBulletSystem(firedBullet);
    }

    public void HurtTank(int hashCode,float hurtdamage)
    {
        mTankSystem.BeHurt(hashCode,hurtdamage);
    }

    public void MaxDistance()
    {
        mStageSystem.MaxDistance(mTankSystem.LTankOnes,mTankSystem.LTankTwos);
    }
}
