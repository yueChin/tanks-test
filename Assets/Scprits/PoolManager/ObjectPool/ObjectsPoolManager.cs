using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectsPoolManager {
    public static Dictionary<string, ObjectsPool> objectsList;
    /// <summary>
    /// 超时时间
    /// </summary>
    public const int Alive_Time = 1 * 60;

    /// <summary>
    /// 对象池
    /// </summary>

    /// <summary>
    /// 添加一个对象组
    /// </summary>
    public static void PushData(string _name)
    {
        if (objectsList == null)
            objectsList = new Dictionary<string, ObjectsPool>();
        if (!objectsList.ContainsKey(_name))
            objectsList.Add(_name, new ObjectsPool(_name));
    }

    /// <summary>
    /// 添加单个对象（首先寻找对象组->添加单个对象）
    /// </summary>
    public static void PushObject(string _name, GameObject _gameObject)
    {
        if (objectsList == null || !objectsList.ContainsKey(_name))
        {
            PushData(_name);//添加对象组
                            //添加对象
        }
        objectsList[_name].PushObject(_gameObject);
    }

    /// <summary>
    /// 移除单个对象，真正的销毁!!
    /// </summary>
    public static void RemoveObject(string _name, GameObject _gameObject)
    {
        if (objectsList == null || !objectsList.ContainsKey(_name))
            return;
        objectsList[_name].RemoveObject(_gameObject);
    }

    /// <summary>
    /// 获取缓存中的对象
    /// </summary>
    public static GameObject GetObject(string _name)
    {
        //Debug.Log(_name);
        if (objectsList == null || !objectsList.ContainsKey(_name))
        {           
            return null;
        }
        //Debug.Log(_name);
        return objectsList[_name].GetObject();
    }

    /// <summary>
    /// 销毁对象，没有真正的销毁!!
    /// </summary>
    public static void DestroyActiveObject(string _name, GameObject _gameObject)
    {
        if (objectsList == null || !objectsList.ContainsKey(_name))
        {
            return;
        }
        objectsList[_name].DestoryObject(_gameObject);
    }

    /// <summary>
    /// 销毁对象，真正的销毁!!
    /// </summary>
    public static void BeyondTimeObject()
    {
        if (objectsList == null)
        {
            return;
        }
        foreach (ObjectsPool OPool in objectsList.Values)
        {
            OPool.BeyondObject();
        }
    }

    /// <summary>
    /// 销毁所有对象，真正的销毁!!
    /// </summary>
    public static void Destroy()
    {
        if (objectsList == null)
        {
            return;
        }
        foreach (ObjectsPool OPool in objectsList.Values)
        {
            OPool.Destory();
        }
        objectsList = null;
    }
}
