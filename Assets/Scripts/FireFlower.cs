using UnityEngine;
using System.Collections;

public class FireFlower : MonoBehaviour {

    //Variables

    AudioManager audioManager;
    public AudioClip deathSound;
    public float lifeTime = 3;
    public float fireSpeed = 10.0f;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
        rb.AddForce(transform.right * fireSpeed);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy") {
            audioManager.PlayAudio(deathSound);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
