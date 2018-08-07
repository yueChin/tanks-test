using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayEffect{
    GameObject PlayEffectNow(Transform _Transform, string _FeatureType, float _DestroyTime);
}
