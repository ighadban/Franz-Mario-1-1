using UnityEngine;
using System.Collections;

public class FireFlower : MonoBehaviour {

    public float lifeTime = 3;
    public float fireSpeed = 10.0f;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, lifeTime);
        rb.AddForce(transform.right * fireSpeed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy") {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
