using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPool  {

    Audio audio;

    /// <summary>
    /// 名称，作为标识
    /// </summary>
    public string name;

    /// <summary>
    /// 对象列表，存储同一个名称的所有对象
    /// </summary>
    public Dictionary<int, Audio> audioList;

    public AudiosPool(string _name)
    {
        this.name = _name;
        this.audioList = new Dictionary<int, Audio>();
    }

    /// <summary>
    /// 添加对象，往同一对象池里添加对象
    /// </summary>
    public Audio PushAudio(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (!this.audioList.ContainsKey(hashKey))
        {
            audio = _gameObject.AddComponent<Audio>();
            this.audioList.Add(hashKey, audio);
            return audio;
        }
        else
        {
            this.audioList[hashKey].Play(1f);
            return audioList[hashKey];
        }
    }

    /// <summary>
    /// 移除并销毁单个对象，真正的销毁对象!!
    /// </summary>
    public void RemoveAudio(GameObject _gameObject)
    {
        int hashKey = _gameObject.GetHashCode();
        if (this.audioList.ContainsKey(hashKey))
        {
            GameObject.Destroy(_gameObject);
            this.audioList.Remove(hashKey);
        }
    }

    /// <summary>
    /// 销毁对象，把所有的同类对象全部删除，真正的销毁对象!!
    /// </summary>
    public void Destory()
    {
        IList<Audio> poolIList = new List<Audio>();
        foreach (Audio poolA in this.audioList.Values)
        {
            poolIList.Add(poolA);
        }
        while (poolIList.Count > 0)
        {
            if (poolIList[0] != null && poolIList[0].gameObject != null)
            {
                GameObject.Destroy(poolIList[0].gameObject);
                poolIList.RemoveAt(0);
            }
        }
        this.audioList = new Dictionary<int, Audio>();
    }

    /// <summary>
    /// 超时检测，超时的就直接删除了，真正的删除!!
    /// </summary>
    public void BeyondAudio()
    {
        IList<Audio> beyondTimeList = new List<Audio>();
        foreach (Audio poolA in this.audioList.Values)
        {
            if (poolA.IsBeyondAliveTime())
            {
                beyondTimeList.Add(poolA);
            }
        }
        int beyondTimeCount = beyondTimeList.Count;
        for (int i = 0; i < beyondTimeCount; i++)
        {
            this.RemoveAudio(beyondTimeList[i].gameObject);
        }
    }

    /// <summary>
    /// 返回没有真正销毁的第一个对象（即池中的destoryStatus为true的对象），并播放
    /// </summary>
    public Audio PlayAudio(float _Volume)
    {
        if (this.audioList == null || this.audioList.Count == 0)
        {
            AddAudio();
        }
        foreach (Audio A in this.audioList.Values)
        {
            if (!A.gameObject.activeSelf)
            {
                A.Play(_Volume);
                return A;
            }
        }
        audio = AddAudio();
        audio.Play(_Volume);
        return audio;
    }    

    /// <summary>
    /// 添加音效
    /// </summary>
    public Audio AddAudio()
    {
        AudioClip ac = FactoryManager.assetFactory.LoadAudioClip(name);
        GameObject go = new GameObject(name);
        AudioSource audioSource = go.AddComponent<AudioSource>();        
        audioSource.clip = ac;
        go.SetActive(false);
        audio = PushAudio(go);
        return audio;
    }
}
