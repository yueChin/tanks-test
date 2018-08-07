using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    /// <summary>
    /// 获取的粒子
    /// </summary>
    private ParticleSystem ps;

    /// <summary>
    /// “销毁”的时间
    /// </summary>
    private float playTime;

    /// <summary>
    /// 跟随物体，如果此物体不为空，特效会跟随父物体移动，直到父物体变为null
    /// </summary>
    public GameObject parent;

    ///<summary>
    /// 销毁状态
    /// </summary>
    public bool destroyStatus;

    ///<summary>
    /// 存取时间
    /// </summary>
    public float aliveTime;

    /// <summary>
    /// 初始化
    /// </summary>

    

    public void Awake()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// 基本的播放，播放完成自动“销毁”
    /// </summary>
    /// <param name="scale"></param>
    public void Play(float scale)
    {
        playTime = 0;
        this.gameObject.SetActive(true);
        ps.Play();
        SetScale(this.transform, 0.8f*scale);
        destroyStatus = false;
    }

    /// <summary>
    /// 自动跟随和销毁用的计时
    /// </summary>
    void Update()
    {
        if (destroyStatus == true) return;
        playTime += Time.deltaTime;
        if (parent != null)
        {
            transform.position = parent.transform.position;
            return;
        }
        if (playTime > ps.main.duration)
        {
            Die();
        }
    }    

    /// <summary>
    /// 设置
    /// </summary>
    /// <param name="t"></param>
    /// <param name="scale"></param>
    public void SetScale(Transform t, float scale)
    {
        for (int i = 0; i < t.childCount; i++)
        {
            SetScale(t.GetChild(i), scale);
        }
        t.localScale = new Vector3(scale,scale, scale);
    }

    /// <summary>
    /// 如果需要显示拖尾效果，需要调用设置父物体
    /// </summary>
    /// <param name="obj"></param>
    public void SetParent(GameObject obj)
    {
        this.parent = obj;
    }

    /// <summary>
    /// 物体“销毁”
    /// </summary>
    public void Die()
    {
        destroyStatus = true;
        gameObject.SetActive(false);        
    }

    ///<summary>
    /// 检测是否超时，返回true或false，没有其他的操作
    /// </summary>
    public bool IsBeyondAliveTime()
    {
        if (!this.gameObject.activeSelf)
            return false;
        if (Time.time - this.aliveTime >= EffectsPoolManager.Alive_Time)
        {
            Debug.Log("已超时!!!!!!");
            return true;
        }
        return false;
    }
}