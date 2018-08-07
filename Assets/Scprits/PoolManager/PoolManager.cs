using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 暂时不用
/// </summary>
public abstract class PoolManager {    
    public static PoolManager Instance { get { return mInstance; } }
    private static PoolManager mInstance;
    //public static Dictionary<string, AudiosPool> audioList;
    public abstract void PushData(string _name);
    public abstract void PushObject(string _name, GameObject _gameObject);
    public abstract void RemoveObject(string _name, GameObject _gameObject);
    public abstract GameObject GetObject(string _name);
    public abstract void DestroyActiveObject(string _name, GameObject _gameObject);
    public abstract void BeyondTimeObject();
    public abstract void Destroy();
}
