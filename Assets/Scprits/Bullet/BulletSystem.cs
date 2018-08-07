using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem :GameSystem {

	public  List<FiredBullet> lFiredBullets = new List<FiredBullet>();

    public override void Update()
    {
        base.Update();
        UpdateBullet();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        FixedUpdateBullet();
    }

    public void AddBulletSystem(FiredBullet firedBullet )
    {
        lFiredBullets.Add(firedBullet);
    }

    public void RemoveBulletSystem(FiredBullet firedBullet )
    {
        lFiredBullets.Remove(firedBullet);
    }

    private void UpdateBullet()
    {
        foreach (FiredBullet fb in lFiredBullets)
        {
            fb.Update();
        }
    }

    private void FixedUpdateBullet()
    {
        foreach (FiredBullet fb in lFiredBullets)
        {
            fb.FixedUpdate();
        }
    }
}
