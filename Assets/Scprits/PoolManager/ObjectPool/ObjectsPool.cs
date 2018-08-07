using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool {
    ///单种类子弹的缓存池
    /// <summary>
    /// 名称，作为标识
    /// </summary>
    public string name;

    /// <summary>
    /// 对象列表，存储同一个名称的所有对象
    /// </summary>
    public Dictionary<int,Object> objectList;

    public ObjectsPool(string _name)
    {
        this.name = _name;
        this.objectList = new Dictionary<int, Object>();
    }

    /// <summary>
    /// 添加对象，往同一对象池里添加对象
    /// </summary>
    public void PushObject(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (!this.objectList.ContainsKey(hashKey))
        {
            this.objectList.Add(hashKey,new Object(_gameObject));
        }
        else
        {
            this.objectList[hashKey].Active();
        }
    }

    /// <summary>
    /// 销毁对象，调用PoolItemTime中的destroy，即也没有真正销毁
    /// </summary>
    public void DestoryObject(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (this.objectList.ContainsKey(hashKey))
        {
            this.objectList[hashKey].Destroy();
        }
    }

    /// <summary>
    /// 返回没有真正销毁的第一个对象（即池中的destoryStatus为true的对象）
    /// </summary>
    public GameObject GetObject()
    {
        if (this.objectList == null || this.objectList.Count == 0)
        {
            return null;
        }
        foreach (Object O in this.objectList.Values)
        {
            if (O.destoryStatus)
            {
                //Debug.Log(FB);
                return O.Active();
            }
            //Debug.Log(FB);
        }
        return null;
    }

    /// <summary>
    /// 移除并销毁单个对象，真正的销毁对象!!
    /// </summary>
    public void RemoveObject(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (this.objectList.ContainsKey(hashKey))
        {
            GameObject.Destroy(_gameObject);
            this.objectList.Remove(hashKey);
        }
    }

    /// <summary>
    /// 销毁对象，把所有的同类对象全部删除，真正的销毁对象!!
    /// </summary>
    public void Destory()
    {
        IList<Object> poolIList = new List<Object>();
        foreach (Object poolBO in this.objectList.Values)
        {
            poolIList.Add(poolBO);
        }
        while (poolIList.Count > 0)
        {
            if (poolIList[0] != null && poolIList[0].gameObject != null)
            {
                GameObject.Destroy(poolIList[0].gameObject);
                poolIList.RemoveAt(0);
            }
        }
        this.objectList = new Dictionary<int, Object>();
    }

    /// <summary>
    /// 超时检测，超时的就直接删除了，真正的删除!!
    /// </summary>
    public void BeyondObject()
    {
        IList<Object> beyondTimeList = new List<Object>();
        foreach (Object poolBO in this.objectList.Values)
        {
            if (poolBO.IsBeyondAliveTime())
            {
                beyondTimeList.Add(poolBO);
            }
        }
        int beyondTimeCount = beyondTimeList.Count;
        for (int i = 0; i < beyondTimeCount; i++)
        {
            this.RemoveObject(beyondTimeList[i].gameObject);
        }
    }
}
