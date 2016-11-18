using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //Variables

    public float coins = 0.0f;
    public float timeLimit = 500.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        timeLimit -= Time.deltaTime;

        if (timeLimit <= 0.0f){
            Application.LoadLevel("GameOver");
            PlayerPrefs.SetString("WIN", "Lose");
        }

	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Enemy") {
            Destroy(col.gameObject);
            
        }
        if (col.tag == "Player") {
            Application.LoadLevel("TestBed");
        }
    }
}
