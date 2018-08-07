using UnityEngine;
using System.Collections;

public class TanksMve : MonoBehaviour {
    public float speed = 5;
    public float angularSpeed = 10;
    public AudioClip idleAudio;
    public AudioClip drivingAudio;
    public int number = 1;

    private Rigidbody mRigidbody;
    private AudioSource mAudio;

	// Use this for initialization
	void Start () {
        mRigidbody = this.GetComponent<Rigidbody>();
        mAudio = this.GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float v = Input.GetAxis("VerticalPlayer" + number);
        float h = Input.GetAxis("HorizontalPlayer" + number);
        mRigidbody.velocity = transform.forward * v * speed;
        mRigidbody.angularVelocity = transform.up * h *angularSpeed;
        if (Mathf.Abs(h) > .1 || Mathf.Abs(v) > 0.1)
        {
            mAudio.clip = drivingAudio;
            if(mAudio.isPlaying==false)
                mAudio.Play();
        }
        else {
            mAudio.clip = idleAudio;
            if(mAudio.isPlaying==false)
                mAudio.Play();
        }
    }
}
