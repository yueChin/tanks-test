using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesAssetProxyFactory:IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory(); 
    private Dictionary<string, GameObject> mTankOne = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mTankTwo = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mTurrets = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mBullets = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();
    private Dictionary<string, Material> mMaterials = new Dictionary<string, Material>();

    public GameObject LoadTankOne(string name)
    {
        if (mTankOne.ContainsKey(name))
        {
            return GameObject.Instantiate(mTankOne[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.OnePath + name) as GameObject;
            mTankOne.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadTankTwo(string name)
    {
        if (mTankTwo.ContainsKey(name))
        {
            return GameObject.Instantiate(mTankTwo[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.TwoPath + name) as GameObject;
            mTankTwo.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadTurret(string name)
    {
        if (mTurrets.ContainsKey(name))
        {
            return GameObject.Instantiate(mTurrets[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.TurretPath + name) as GameObject;
            mTurrets.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }
    public GameObject LoadBullet(string name)
    {
        if (mBullets.ContainsKey(name))
        {
            return GameObject.Instantiate(mBullets[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.BulletPath + name) as GameObject;
            mBullets.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public GameObject LoadEffect(string name)
    {
        if (mEffects.ContainsKey(name))
        {
            return GameObject.Instantiate(mEffects[name]);
        } else
        {
            GameObject asset = mAssetFactory.LoadAsset(ResourcesAssetFactory.EffectPath + name) as GameObject;
            mEffects.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }

    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];
        } else
        {
            AudioClip audio = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name, audio);
            return audio;
        }
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];
        } else
        {
            Sprite sprite = mAssetFactory.LoadSprite(name);
            mSprites.Add(name, sprite);
            return sprite;
        }
    }

    public Material LoadMaterial(string name)
    {
        if (mMaterials.ContainsKey(name))
        {
            return mMaterials[name];
        }
        else
        {
            Material material = mAssetFactory.LoadMaterial(name);
            mMaterials.Add(name, material);
            return material;
        }
    }
}
