using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

    //Variables

    GameManager gameManager;
    AudioManager audioManager;

    public float goldGift = 10.0f;
    public float lifeTime = 0.5f;
    public AudioClip coinPickup;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        audioManager.PlayAudio(coinPickup);
        gameManager.coins += goldGift;
        Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
