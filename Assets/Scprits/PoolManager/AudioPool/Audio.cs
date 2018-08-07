using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour  {

    /// <summary>
    /// 获取的音源组件
    /// </summary>
    private AudioSource mAs;

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

    public void Awake()
    {
        mAs = this.gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// 播放，播放完成会自动销毁
    /// </summary>
    /// <param name="volume"></param>
    public void Play(float volume)
    {               
        this.gameObject.SetActive(true);
        mAs.Play();
        SetVulome(volume);
        destroyStatus = false;
    }

    /// <summary>
    /// 停止音乐，直接销毁物体
    /// </summary>
    public void Stop() {
        mAs.Stop();
    }

    /// <summary>
    /// 播放完以后自动“销毁”,有父物体就会跟随
    /// </summary>
    void Update()
    {
        if (destroyStatus == true) return;
        if (parent != null)
        {
            transform.position = parent.transform.position;
            return;
        }
        if (!mAs.isPlaying)
        {
            Die();
        }
    }

    public void SetVulome(float volume)
    {
        mAs.volume = volume;
    }

    /// <summary>
    /// 音源跟随父物体，类似于在父物体下挂载组件
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
        if (Time.time - this.aliveTime >= AudiosPoolManager.Alive_Time)
        {
            Debug.Log("已超时!!!!!!");
            return true;
        }
        return false;
    }
}
