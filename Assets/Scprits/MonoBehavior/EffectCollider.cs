using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCollider : MonoBehaviour {
    private ParticleSystem mPS;
    private Rigidbody mRb;
    private Bullet mBullet;
    private Vector3 mPos;
    // Use this for initialization
    void Start () {
        mPS = GetComponent<ParticleSystem>();
        mPos = gameObject.transform.position;
	}

    public void SetCollider(Bullet bullet)
    {
        mBullet = bullet;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Tank")
        {
            int collider = other.gameObject.GetHashCode();
            GameFacade.Instance.HurtTank(collider, (mBullet.Damage * 0.1f));
            mRb = other.GetComponent<Rigidbody>();
            if (mRb!= null)
            {
                mRb.AddForce((mPos - other.transform.position) * 250);
            }            
        }
    }

}
