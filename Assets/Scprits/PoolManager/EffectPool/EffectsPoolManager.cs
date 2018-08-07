using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsPoolManager {

    public static Dictionary<string, EffectsPool> effectsList;
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
        if (effectsList == null)
            effectsList = new Dictionary<string, EffectsPool>();
        if (!effectsList.ContainsKey(_name))
            effectsList.Add(_name, new EffectsPool(_name));
    }

    /// <summary>
    /// 添加单个对象（首先寻找对象组->添加单个对象）
    /// </summary>
    public static void PushEffect(string _name, GameObject _gameObject)
    {
        if (effectsList == null || !effectsList.ContainsKey(_name))
        {
            PushData(_name);//添加对象组
                            //添加对象
        }
        effectsList[_name].PushEffect(_gameObject);
    }

    /// <summary>
    /// 移除单个对象，真正的销毁!!
    /// </summary>
    public static void RemoveEffect(string _name, GameObject _gameObject)
    {
        if (effectsList == null || !effectsList.ContainsKey(_name))
            return;
        effectsList[_name].RemoveEffect(_gameObject);
    }    

    /// <summary>
    /// 销毁对象，真正的销毁!!
    /// </summary>
    public static void BeyondTimeObject()
    {
        if (effectsList == null)
        {
            return;
        }
        foreach (EffectsPool EPool in effectsList.Values)
        {
            EPool.BeyondEffect();
        }
    }

    /// <summary>
    /// 销毁对象池，真正的销毁!!
    /// </summary>
    public static void Destroy()
    {
        if (effectsList == null)
        {
            return;
        }
        foreach (EffectsPool EPool in effectsList.Values)
        {
            EPool.Destory();
        }
        effectsList = null;
    }

    /// <summary>
    /// 拖尾特效，如果父物体不存在，会自动调用偏移特效
    /// </summary>
    /// <param name="_EffectName"></param>
    /// <param name="_ParentGameObject"></param>
    /// <param name="_Offset"></param>
    /// <param name="_Scale"></param>
    /// <returns></returns>
    public static void FollowEffect(string _EffectName, GameObject _ParentGameObject, Vector3 _Offset, float _Scale)
    {        
        Effect ge = PointOffsetEffect(_EffectName, Vector3.zero, _Offset, _Scale);
        if (ge == null) return;
        ge.SetParent(_ParentGameObject);
        ge.transform.position += _Offset;
    }

    /// <summary>
    ///  相对于原点的偏移的特效，如果偏移不存在，会自动调用原点特效
    /// </summary>
    /// <param name="_Effectname"></param>
    /// <param name="_Offset"></param>
    /// <param name="_Scale"></param>
    /// <returns></returns>
    public static Effect PointOffsetEffect(string _Effectname, Vector3 _AbsPosition, Vector3 _Offset, float _Scale)
    {
        Effect ge = PointFixedEffect(_Effectname,_AbsPosition, _Scale);
        if (ge == null) return null;
        ge.transform.position += _Offset;
        return ge;
    }

    /// <summary>
    /// 固定点特效
    /// </summary>
    /// <param name="_EffectName"></param>
    /// <param name="_AbsPosition"></param>
    /// <param name="_Scale"></param>
    public static Effect PointFixedEffect(string _EffectName, Vector3 _AbsPosition, float _Scale)
    {
        Effect ge = PointEffect(_EffectName, _Scale);
        if (ge == null) return null;        
        ge.transform.position = _AbsPosition;
        return ge;
    }

    /// <summary>
    /// 特效原点特效，如果不存在，会自动创建
    /// </summary>
    /// <param name="_name"></param>
    /// <param name="_Scale"></param>
    /// <returns></returns>
    public static Effect PointEffect(string _Name, float _Scale)
    {
        if (effectsList == null || !effectsList.ContainsKey(_Name))
        {
            CreateEffect(_Name);
        }
        return effectsList[_Name].PlayEffect(_Scale);
    }

    /// <summary>
    /// 创建特效池,并把特效添加到特效池中
    /// </summary>
    /// <param name="_Name"></param>
    /// <param name="_Scale"></param>
    /// <returns></returns>
    public static void CreateEffect(string _Name)
    {
        //Debug.Log("2");
        GameObject go = FactoryManager.assetFactory.LoadEffect(_Name);
        go.SetActive(false);
        PushEffect(_Name, go);
    }
}
