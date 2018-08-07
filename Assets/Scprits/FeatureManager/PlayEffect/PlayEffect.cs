using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : IPlayEffect
{
    public GameObject PlayEffectNow(Transform _Transform, string _EffectType,float _DestroyTime)
    {
        GameObject effect = ObjectsPoolManager.GetObject(_EffectType); //从对象池取出物体
        //Debug.Log(effect);
        if (effect != null)
        {
            effect.transform.position = _Transform.position;
            effect.transform.rotation = _Transform.rotation;
            return effect;
        }
        else
        {
            GameObject go = FactoryManager.assetFactory.LoadEffect(_EffectType);
            go.AddComponent<DestroyTime>().SetDestroyTime(_EffectType, _DestroyTime); //添加自动销毁（取消激活）的脚本
            go.transform.position = _Transform.position;
            ObjectsPoolManager.PushObject(_EffectType, go); //往对象池中添加物体，要从assetfactory 里拿，不然传进来的是prefab，第一次实例的是clone
            return go;
        }
    }
}
