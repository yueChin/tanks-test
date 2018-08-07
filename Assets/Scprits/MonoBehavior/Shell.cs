using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

    public GameObject explosion;
    public AudioClip audioSource;

    public void OnTriggerEnter(Collider other)
    {
        GameObject.Instantiate(explosion,transform.position,transform.rotation);
        AudioSource.PlayClipAtPoint(audioSource,transform.position);
        if (other.tag == "Tank")
        {
            other.SendMessage("TakeDamage");
        }
        Destroy(gameObject);        
    }


}
