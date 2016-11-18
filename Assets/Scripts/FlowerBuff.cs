using UnityEngine;
using System.Collections;

public class FlowerBuff : MonoBehaviour {

    //Variables

    AudioManager audioManager;

    public AudioClip powerup;

    // Use this for initialization
    void Start () {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        
        //give player character fire flower buff
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);

            collision.gameObject.GetComponent<CharacterController2D>().health = 3;

            audioManager.PlayAudio(powerup);
        }
    }
}
