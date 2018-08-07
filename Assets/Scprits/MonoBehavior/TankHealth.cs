using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour {
    public int hp = 100;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    public Slider hpSlider;
    public int hpTotal;

	// Use this for initialization
	void Start () {
        hpTotal = hp;
        hpSlider = gameObject.GetComponentInChildren<Slider>();
        hpSlider.value = (float)hp / hpTotal;
    }
    
	// Update is called once per frame
	void Update () {
        
    }

    void TakeDamage() {
        if (hp <= 0) return;
        hp -= (int)Random.Range(5, 20);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0) {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, Camera.main.transform.position);
            Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);            
            Destroy(gameObject);            
        }
    }
}
