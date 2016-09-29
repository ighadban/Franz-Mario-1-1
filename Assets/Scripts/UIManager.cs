using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text coins;
    public Text timeLimit;

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        coins.text = "Coins: " + gameManager.coins;
        timeLimit.text = "Time limit: " + gameManager.timeLimit;
	}
}
