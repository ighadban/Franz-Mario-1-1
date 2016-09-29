using UnityEngine;
using System.Collections;

public class Gold : MonoBehaviour {

    GameManager gameManager;

    public float goldGift = 10.0f;
    public float lifeTime = 0.5f;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.coins += goldGift;
        Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
