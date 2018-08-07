using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSystem : GameSystem{

    private List<Tank> lTankOnes = new List<Tank>();
    private List<Tank> lTankTwos = new List<Tank>();

    public List<Tank> LTankOnes { get { return lTankOnes; } }
    public List<Tank> LTankTwos { get { return lTankTwos; } }

    public void AddTankOne(Tank1 _Tank) {
        lTankOnes.Add(_Tank);
    }

    public void RemoveTankOne(Tank1 _Tank) {
        lTankOnes.Remove(_Tank);
    }

    public void AddTankTwo(Tank2 _Tank)
    {
        lTankTwos.Add(_Tank);
    }

    public void RemoveTankTwo(Tank2 _Tank)
    {
        lTankTwos.Remove(_Tank);
    }

    public override void Init()
    {
        base.Init();
        foreach (Tank1 t in lTankOnes)
        {
            t.Init();
        }
        foreach (Tank2 t in lTankTwos)
        {
            t.Init();
        }
    }

    public override void Release()
    {
        base.Release();
    }

    public override void FixedUpdate()
    {
        foreach (Tank1 o in lTankOnes)
        {
            o.FixedUpdate();
        }

        foreach (Tank2 t in lTankTwos)
        {
            t.FixedUpdate();
        }
    }

    public override void Update()
    {        
        UpdateTankOne();
        UpdateTankTwo();
        RemoveTankIsKilled(lTankOnes);
        RemoveTankIsKilled(lTankTwos);
    }

    private void UpdateTankOne()
    {
        foreach (Tank1 o in lTankOnes)
        {
            o.Search(lTankTwos);
            o.Update();            
        }
    }

    private void UpdateTankTwo()
    {
        foreach (Tank2 t in lTankTwos)
        {
            t.Search(lTankOnes);
            t.Update();            
        }
    }

    /// <summary>
    /// 移除被消灭的坦克
    /// </summary>
    /// <param name="tanks"></param>
    private void RemoveTankIsKilled(List<Tank> tanks)
    {
        List<Tank> canDestroyes = new List<Tank>();
        if (tanks.Count == 0)
        {
            float temp = 0;
            temp += Time.deltaTime;
            if(temp > 5)
            GameFacade.Instance.GameIsOver();
        }
        foreach (Tank t in tanks)
        {
            if (t.CanDestroy)
            {
                canDestroyes.Add(t);
            }
        }
        foreach (Tank t in canDestroyes)
        {
            t.Release();
            tanks.Remove(t);
        }
    }

    /// <summary>
    /// 坦克受到伤害
    /// </summary>
    /// <param name="hasdCode"></param>
    /// <param name="damage"></param>
    public void BeHurt(int hasdCode,float damage)
    {
        foreach (Tank t in lTankOnes)
        {
            if (t.GameObject.GetHashCode() == hasdCode)
            {
                t.UnderAttack((int)damage);
            }
           
        }
        foreach (Tank t in lTankTwos)
        {
            if (t.GameObject.GetHashCode() == hasdCode)
            {
                t.UnderAttack((int)damage);
            }            
        }
    }

}
