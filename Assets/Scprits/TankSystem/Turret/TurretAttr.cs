using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttr  {
    private float mMaxHoldTime;
    private TurretType mTurretType;
    private AudioType mFireAudio;
    
    public float MaxHoldTime { get { return mMaxHoldTime; } }
    public TurretType TurretType { get { return mTurretType; } }
    public AudioType FireAudio { get { return mFireAudio; } }

    public TurretAttr(TurretType turretType,AudioType fireAudio,float maxHoldTime) {
        mTurretType = turretType;
        mFireAudio = fireAudio;
        mMaxHoldTime = maxHoldTime;
    }

}
