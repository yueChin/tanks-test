using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesAssetFactory:IAssetFactory
{
    public const string OnePath = "Tanks/Tank1/";
    public const string TwoPath = "Tanks/Tank2/";
    public const string TurretPath = "Turrets/";
    public const string BulletPath = "Bullets/";
    public const string EffectPath = "Effects/";
    public const string AudioPath = "Audios/";
    public const string SpritePath = "Sprites/";
    public const string MaterialPath = "Materials/";

    public GameObject LoadTankOne(string name)
    {
        return InstantiateGameObject(OnePath + name);
    }

    public GameObject LoadTankTwo(string name)
    {
        return InstantiateGameObject(TwoPath + name);
    }

    public GameObject LoadTurret(string name)
    {
        return InstantiateGameObject(TurretPath + name);
    }

    public GameObject LoadBullet(string name)
    {
        return InstantiateGameObject(BulletPath + name);
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(AudioPath + name, typeof(AudioClip)) as AudioClip;
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    public Material LoadMaterial(string name)
    {
        return Resources.Load(MaterialPath + name, typeof(Material)) as Material;
    }

    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("无法加载资源，路径:" + path); return null;
        }
        return UnityEngine.GameObject.Instantiate(o) as GameObject;
    }

    public UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null) {  
            Debug.LogError("无法加载资源，路径:" + path); return null;
        }
        return o;
    }
}