using UnityEngine;
using System.Collections;

public class Mushroom : MovementBase {

    //Variables

    public AudioClip mushroom;

    public override void OnCollisionEnter2D(Collision2D collision) {
        //change direction when collide with wall or other enemies
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy") {
            //Debug.Log("hit");
            direction.x *= -1;
        }

        if (collision.gameObject.tag == "Player") {

            Destroy(this.gameObject);

            collision.gameObject.GetComponent<CharacterController2D>().health = 2;

            audioManager.PlayAudio(mushroom);
        }
    }

}
