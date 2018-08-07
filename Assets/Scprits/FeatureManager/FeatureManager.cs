using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FeatureManager
{

    [Obsolete]
    public static void PlayEffect(EffectType _EffectType, Transform _Transform, float _DestroyTime)
    {
        Debug.Log("1");
        new PlayEffect().PlayEffectNow(_Transform, _EffectType.ToString(), _DestroyTime);
    }

    [Obsolete]
    public static void PlayAudio(AudioType _AudioType, Transform _Transform, float _DestroyTime)
    {
        Debug.Log("2");
        new PlayAudio().PlayAudioNow(_Transform, _AudioType.ToString(), _DestroyTime);
    }

    [Obsolete]
    public static GameObject HoldOnAudio(AudioType _AudioType, Transform _Transform)
    {
        GameObject mAudioGO = new PlayAudio().PlayAudioNow(_Transform, _AudioType.ToString());
        return mAudioGO;
    }
}
