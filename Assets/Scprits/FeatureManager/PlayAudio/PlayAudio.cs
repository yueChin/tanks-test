using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : IPlayAudio
{
    
    public GameObject PlayAudioNow(Transform _Transform, string _FeatureType,float _DestroyTime)
    {
        GameObject audio = ObjectsPoolManager.GetObject(_FeatureType); //从对象池取出物体
        //Debug.Log(audio);
        if (audio != null)
        {
            audio.transform.position = _Transform.position;
            audio.GetComponent<AudioSource>().Play();            
            return audio;
        }
        else
        {            
            GameObject go = new GameObject(_FeatureType.ToString());            
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip _audioClip = FactoryManager.assetFactory.LoadAudioClip(_FeatureType);
            audioSource.clip = _audioClip;
            go.AddComponent<DestroyTime>().SetDestroyTime(_FeatureType,_DestroyTime);
            go.transform.position = _Transform.position;
            audioSource.Play();
            ObjectsPoolManager.PushObject(_FeatureType, go); //往对象池中添加物体，要从assetfactory 里拿，不然传进来的是prefab，第一次实例的是clone
            return go;
        }
    }


    public GameObject PlayAudioNow(Transform _Transform, string _FeatureType)
    {
        GameObject audio = ObjectsPoolManager.GetObject(_FeatureType); //从对象池取出物体
        //Debug.Log(audio);
        if (audio != null)
        {
            audio.transform.position = _Transform.position;
            audio.GetComponent<AudioSource>().Play();
            return audio;
        }
        else
        {
            GameObject go = new GameObject(_FeatureType.ToString());
            AudioSource audioSource = go.AddComponent<AudioSource>();
            AudioClip _audioClip = FactoryManager.assetFactory.LoadAudioClip(_FeatureType);
            audioSource.clip = _audioClip;
            go.transform.position = _Transform.position;
            audioSource.Play();
            ObjectsPoolManager.PushObject(_FeatureType, go); //往对象池中添加物体，要从assetfactory 里拿，不然传进来的是prefab，第一次实例的是clone
            return go;
        }
    }

}
