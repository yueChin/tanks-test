using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITool  {

    public static GameObject GetCanvas(string name = "Canvas")
    {
        return GameObject.Find(name);
    }

    public static T FindChild<T>(GameObject parent, string childName)
    {
        GameObject uiGO = UnityTool.FindOneOfActiveChild(parent, childName);
        if (uiGO == null)
        {
            Debug.LogError("在游戏物体" + parent + "下面查找不到" + childName);
            return default(T);
        }
        return uiGO.GetComponent<T>();
    }

    public static GameObject FindOneOfActiveChild(GameObject parent, string childName)
    {
        RectTransform[] children = parent.GetComponentsInChildren<RectTransform>();
        Debug.Log(children);
        bool isFinded = false;
        RectTransform child = null;
        foreach (RectTransform t in children)
        {
            Debug.Log(t.name);
            if (t.name == childName)
            {
                if (isFinded)
                {
                    Debug.LogWarning("在游戏物体" + parent + "下存在不止一个子物体:" + childName);
                }
                isFinded = true;
                child = t;
            }
        }
        if (isFinded) return child.gameObject;
        return null;
    }
}
