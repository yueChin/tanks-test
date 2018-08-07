using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayAudio{
    GameObject PlayAudioNow(Transform _Transform, string _FeatureType, float _DestroyTime);
    GameObject PlayAudioNow(Transform _Transform, string _FeatureType);
}
