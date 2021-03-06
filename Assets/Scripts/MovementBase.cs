﻿using UnityEngine;
using System.Collections;

public class MovementBase : MonoBehaviour {

    //Variables

    public AudioManager audioManager;

    public Vector3 direction = new Vector3(-1, 0, 0);

    public float moveSpeed;

    public virtual void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(direction * moveSpeed);
	}

    public virtual void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy") {
            Debug.Log("hit");
            direction.x *= -1;
        }
    }
}
