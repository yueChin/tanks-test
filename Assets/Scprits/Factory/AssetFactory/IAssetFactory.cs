using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public interface IAssetFactory
{
    GameObject LoadTankOne(string name);
    GameObject LoadTankTwo(string name);
    GameObject LoadTurret(string name);
    GameObject LoadBullet(string name);
    GameObject LoadEffect(string name);
    AudioClip LoadAudioClip(string name);
    Sprite LoadSprite(string name);
    Material LoadMaterial(string name);
}
