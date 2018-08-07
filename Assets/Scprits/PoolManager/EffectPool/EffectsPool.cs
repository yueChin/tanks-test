using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPool
{
    Effect effect;

    /// <summary>
    /// 名称，作为标识
    /// </summary>
    public string name;

    /// <summary>
    /// 对象列表，存储同一个名称的所有对象
    /// </summary>
    public Dictionary<int, Effect> effectList;

    public EffectsPool(string _name)
    {
        this.name = _name;
        this.effectList = new Dictionary<int, Effect>();
    }

    /// <summary>
    /// 添加对象，往同一对象池里添加对象
    /// </summary>
    public Effect PushEffect(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (!this.effectList.ContainsKey(hashKey))
        {
            effect = _gameObject.AddComponent<Effect>();
            this.effectList.Add(hashKey, effect);
            return effect;
        }
        else
        {
            this.effectList[hashKey].Play(1f);
            return effectList[hashKey];
        }
    }
    
    /// <summary>
    /// 移除并销毁单个对象，真正的销毁对象!!
    /// </summary>
    public void RemoveEffect(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (this.effectList.ContainsKey(hashKey))
        {
            GameObject.Destroy(_gameObject);
            this.effectList.Remove(hashKey);
        }
    }

    /// <summary>
    /// 销毁对象，把所有的同类对象全部删除，真正的销毁对象!!
    /// </summary>
    public void Destory()
    {
        IList<Effect> poolIList = new List<Effect>();
        foreach (Effect poolBO in this.effectList.Values)
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
        this.effectList = new Dictionary<int, Effect>();
    }

    /// <summary>
    /// 超时检测，超时的就直接删除了，真正的删除!!
    /// </summary>
    public void BeyondEffect()
    {
        IList<Effect> beyondTimeList = new List<Effect>();
        foreach (Effect poolE in this.effectList.Values)
        {
            if (poolE.IsBeyondAliveTime())
            {
                beyondTimeList.Add(poolE);
            }
        }
        int beyondTimeCount = beyondTimeList.Count;
        for (int i = 0; i < beyondTimeCount; i++)
        {
            this.RemoveEffect(beyondTimeList[i].gameObject);
        }
    }

    /// <summary>
    /// 返回没有真正销毁的第一个对象（即池中的destoryStatus为true的对象），并播放
    /// </summary>
    public Effect PlayEffect(float _Scale)
    {
        if (this.effectList == null || this.effectList.Count == 0)
        {
            AddEffect();
        }
        foreach (Effect E in this.effectList.Values)
        {
            if (!E.gameObject.activeSelf)
            {
                E.Play(_Scale);
                return E;
            }
        }
        effect = AddEffect();
        effect.Play(_Scale);
        return effect;
    }

    /// <summary>
    /// 添加特效
    /// </summary>
    public Effect AddEffect()
    {
        GameObject go = FactoryManager.assetFactory.LoadEffect(name);
        go.SetActive(false);
        effect = PushEffect(go);
        return effect;
    }
}
