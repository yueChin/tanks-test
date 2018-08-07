using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TankAttack : MonoBehaviour {
    public GameObject bulletPrefab;    
    public KeyCode fireKey = KeyCode.J;
    public AudioClip AttackAudio;
    private AudioSource mAudioSource;
    public Transform fireSpot;
    private float mHoldTime;
    private float mMaxTime = 5f;

    // Use this for initialization
    void Start () {
        fireSpot = transform.Find("FireSpot");
    }
	
	// Update is called once per frame
	void Update () {        
        if (Input.GetKeyDown(fireKey) ) //当开火键 按下，计时按下的时间
        {
            AudioSource.PlayClipAtPoint(AttackAudio, gameObject.transform.position);
            GameObject shell = GameObject.Instantiate(bulletPrefab,fireSpot.position,fireSpot.rotation);
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward*Random.Range(10, 20);
            //test
            
            Vector3 vector3 = new Vector3(1, 0, 0);
            Quaternion quaternion = quaternion = Quaternion.AngleAxis(15, vector3);
            vector3.z = 4;
            
            
            //Debug.Log(vector);
            //Debug.DrawRay(vector3, vector, Color.red, 100);

            //quaternion = Quaternion.Euler(60, 60, 60);
            ////Debug.Log(quaternion.x + "" + quaternion.y + "" + quaternion.z + "" + quaternion.w);
            //vector = quaternion * vector3;
            //Debug.Log(vector);
            //Debug.DrawRay(vector3, vector, Color.white, 100);

            //quaternion = Quaternion.Euler(30, 30, 30);            
            ////Debug.Log(quaternion.x + "" + quaternion.y + "" + quaternion.z + "" + quaternion.w);
            //vector = quaternion * vector3;
            //Debug.Log(vector);
            //Debug.DrawRay(vector3, vector, Color.black,100);

            //vector = Matrix4x4.Rotate(quaternion).MultiplyVector(vector3);

            //Quaternion temp = quaternion;
            ////x = sin(Y / 2)sin(Z / 2)cos(X / 2) + cos(Y / 2)cos(Z / 2)sin(X / 2)
            ////y = sin(Y / 2)cos(Z / 2)cos(X / 2) + cos(Y / 2)sin(Z / 2)sin(X / 2)
            ////z = cos(Y / 2)sin(Z / 2)cos(X / 2) - sin(Y / 2)cos(Z / 2)sin(X / 2)
            ////w = cos(Y / 2)cos(Z / 2)cos(X / 2) - sin(Y / 2)sin(Z / 2)sin(X / 2)
            //float x = Mathf.Sin(15) * Mathf.Sin(15)* Mathf.Cos(15) + Mathf.Cos(15) * Mathf.Cos(15) * Mathf.Sin(15); 
            //float y = Mathf.Sin(15) * Mathf.Cos(15) * Mathf.Cos(15) + Mathf.Cos(15) * Mathf.Sin(15) * Mathf.Sin(15);
            //float z = Mathf.Cos(15) * Mathf.Sin(15) * Mathf.Cos(15) - Mathf.Sin(15) * Mathf.Cos(15) * Mathf.Sin(15);
            //float w = Mathf.Cos(15) * Mathf.Cos(15) * Mathf.Cos(15) - Mathf.Sin(15) * Mathf.Sin(15) * Mathf.Sin(15);
            //Debug.Log(x + "" + y + "" + z+ "" +w);
            //temp.Set(x,y,z,w);
            //Debug.Log(temp);
            //quaternion = Quaternion.AngleAxis(15, vector);
            //Debug.DrawRay(,vector, Color.red, 50);
            //Debug.Log(quaternion);
            //vector = quaternion * vector3;
            //Debug.DrawRay(new Vector3(0,0,0), vector, Color.blue, 100);

        }
    }
    
}
