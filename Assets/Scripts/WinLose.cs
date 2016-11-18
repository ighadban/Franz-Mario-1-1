using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinLose : MonoBehaviour {

    //Variables

    public Text winLose;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        winLose.text = "You " + PlayerPrefs.GetString("WIN");
	}

    public void restartGame() {
        Application.LoadLevel("TestBed");
    }
}
