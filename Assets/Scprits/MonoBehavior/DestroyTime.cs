using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {

    private float mDestroyTime = 1.5f ;
    private string mFeature;

    public void SetDestroyTime(string _Feature, float _DestroyTime)
    {
        mFeature = _Feature;
        mDestroyTime = _DestroyTime;
    }
    void Start () {
        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }
        StartCoroutine("DenyA");
    }	
	// Update is called once per frame
	void Update ()
    {
        //Invoke("DenyA", mDestroyTime);  //Invoke 准入时机很重要，不推荐
    }
    private IEnumerator DenyA()
    {
        yield return new WaitForSeconds(5);
        DenyB();
    }

    private void DenyB()
    {
        ObjectsPoolManager.DestroyActiveObject(mFeature, gameObject);
    }

}
