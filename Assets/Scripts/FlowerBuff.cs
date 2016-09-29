using UnityEngine;
using System.Collections;

public class FlowerBuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            collision.gameObject.GetComponent<CharacterController2D>().health = 3;
        }
    }
}
