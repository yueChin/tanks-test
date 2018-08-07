using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFeature {
    protected BulletType mBulletType;
    protected AudioType mExplosionAudio;
    protected EffectType mExplosionEffect;

    public BulletType BulletType { get { return mBulletType; } }
    public AudioType ExplosionAudio { get { return mExplosionAudio; } }
    public EffectType ExplosionEffect { get { return mExplosionEffect; } }
    public BulletFeature(BulletType bulletType, AudioType explosionAudio, EffectType explosionEffect)
    {
        mBulletType = bulletType;
        mExplosionAudio = explosionAudio;
        mExplosionEffect = explosionEffect;
    }
}
