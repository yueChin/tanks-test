using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem :GameSystem {

    private GameObject mMainCamera;
    private Transform mFollowOne;
    private Transform mFollowTwo;
    private Camera mCamera;
    private Vector3 mOffset;

    public override void Init()
    {
        base.Init();
        InitView();
    }

    public override void LateUpdate()
    {
        base.LateUpdate();
        UpdateView();
    }

    public void MaxDistance(List<Tank> tanks1, List<Tank> tanks2)
    {
        float tempDistance = 0;
        Transform tempFollow1 = null;
        Transform tempFollow2 = null;
        if (tanks1 == null || tanks2 == null) return;
        foreach (Tank1 t1 in tanks1)
        {
            foreach (Tank2 t2 in tanks2)
            {
                if (Vector3.Distance(t1.Position, t2.Position) > tempDistance)
                {
                    tempFollow1 = t1.GameObject.transform;
                    tempFollow2 = t2.GameObject.transform;
                    tempDistance = Vector3.Distance(t1.Position, t2.Position);
                }
            }
        }
        mFollowOne = tempFollow1;
        mFollowTwo = tempFollow2;
    }

    private void InitView()
    {
        GameFacade.Instance.MaxDistance();
        mMainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        //Debug.Log(mMainCamera);
        //Debug.Log(mFollowOne);
        //Debug.Log(mFollowTwo);
        mOffset = mMainCamera.transform.position + (mFollowOne.position + mFollowTwo.position) / 2;
        mCamera = mMainCamera.GetComponent<Camera>();        
    }

    private void UpdateView()
    {
        GameFacade.Instance.MaxDistance();
        if (mFollowOne == null || mFollowTwo == null) return;
        mMainCamera.transform.position = (mFollowOne.position + mFollowTwo.position) / 2 + new Vector3(0, 70, -25);
        float distance = Vector3.Distance(mFollowOne.position, mFollowTwo.position);
        float size = distance * 0.68f;
        if (size > 6)
        {
            mCamera.orthographicSize = size;
        }
        else
        {
            size = 6;
        }
    }
}
