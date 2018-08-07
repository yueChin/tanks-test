using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiosPoolManager {
    public static Dictionary<string, AudiosPool> AudiosList;
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
        if (AudiosList == null)
            AudiosList = new Dictionary<string, AudiosPool>();
        if (!AudiosList.ContainsKey(_name))
            AudiosList.Add(_name, new AudiosPool(_name));
    }

    /// <summary>
    /// 添加单个对象（首先寻找对象组->添加单个对象）
    /// </summary>
    public static void PushAudio(string _name, GameObject _gameObject)
    {
        if (AudiosList == null || !AudiosList.ContainsKey(_name))
        {
            PushData(_name);//添加对象组
                            //添加对象
        }
        AudiosList[_name].PushAudio(_gameObject);
    }

    /// <summary>
    /// 移除单个对象，真正的销毁!!
    /// </summary>
    public static void RemoveAudio(string _name, GameObject _gameObject)
    {
        if (AudiosList == null || !AudiosList.ContainsKey(_name))
            return;
        AudiosList[_name].RemoveAudio(_gameObject);
        //ObjectsPoolManager.RemoveObject(_name, _gameObject);
    }

    /// <summary>
    /// 销毁对象，真正的销毁!!
    /// </summary>
    public static void BeyondTimeObject()
    {
        if (AudiosList == null)
        {
            return;
        }
        foreach (AudiosPool APool in AudiosList.Values)
        {
            APool.BeyondAudio();
        }
        //ObjectsPoolManager.BeyondTimeObject();
    }

    /// <summary>
    /// 销毁对象池，真正的销毁!!
    /// </summary>
    public static void Destroy()
    {
        if (AudiosList == null)
        {
            return;
        }
        foreach (AudiosPool OPool in AudiosList.Values)
        {
            OPool.Destory();
        }
        AudiosList = null;
        //ObjectsPoolManager.Destroy();
    }

    /// <summary>
    /// 跟随音效
    /// </summary>
    /// <param name="_Name"></param>
    /// <param name="_ParentGameObject"></param>
    /// <param name="_Offset"></param>
    /// <param name="_Scale"></param>
    public static void FollowAudio(string _Name, GameObject _ParentGameObject, Vector3 _Offset, float _Scale)
    {
        Audio ga = PointOffsetAudio(_Name, Vector3.zero, _Offset, _Scale);
        if (ga == null) return;
        ga.SetParent(_ParentGameObject);
        ga.transform.position += _Offset;
    }

    /// <summary>
    /// 固定点偏移音效
    /// </summary>
    /// <param name="_Name"></param>
    /// <param name="_AbsPosition"></param>
    /// <param name="_Offset"></param>
    /// <param name="_Vulome"></param>
    /// <returns></returns>
    public static Audio PointOffsetAudio(string _Name, Vector3 _AbsPosition, Vector3 _Offset, float _Vulome)
    {
        Audio ga = PointFixedAudio(_Name, _AbsPosition, _Vulome);
        if (ga == null) return null;
        ga.transform.position += _Offset;
        return ga;
    }

    /// <summary>
    /// 固定点音效
    /// </summary>
    /// <param name="_AudioName"></param>
    /// <param name="_AbsPosition"></param>
    /// <param name="_Vulome"></param>
    /// <returns></returns>
    public static Audio PointFixedAudio(string _AudioName, Vector3 _AbsPosition, float _Vulome)
    {
        Audio ga = PointOriginAudio(_AudioName, _Vulome);
        if (ga == null) return null;
        ga.transform.position = _AbsPosition;
        return ga;
    }

    /// <summary>
    /// 原点音效
    /// </summary>
    /// <param name="_Name"></param>
    /// <param name="_Vulome"></param>
    /// <returns></returns>
    public static Audio PointOriginAudio(string _Name, float _Vulome)
    {
        //GameObject go = ObjectsPoolManager.GetObject(_Name);
        //Audio audio = go.GetComponent<Audio>();
        //if(audio == null)
        //{
        //    CreateAudio(_Name);
        //}
        //go = ObjectsPoolManager.GetObject(_Name);
        //audio = go.GetComponent<Audio>();
        //audio.Play(_Vulome);
        //return audio;
        if (AudiosList == null || !AudiosList.ContainsKey(_Name)) //如果连音效池都不存在的话
        {
            CreateAudio(_Name);
        }
        return AudiosList[_Name].PlayAudio(_Vulome);
    }

    /// <summary>
    /// 创建音效池
    /// </summary>
    /// <param name="_Name"></param>
    public static void CreateAudio(string _Name)
    {
        AudioClip ac = FactoryManager.assetFactory.LoadAudioClip(_Name);
        GameObject go = new GameObject(_Name);
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.clip = ac;
        go.SetActive(false);
        PushAudio(_Name,go);
        //ObjectsPoolManager.PushObject(_Name, go);
    }

}
