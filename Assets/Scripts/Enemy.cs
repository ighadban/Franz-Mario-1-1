using UnityEngine;
using System.Collections;

public class Enemy : MovementBase {

    //Variables

    public AudioClip deathSound;

    //destroy player/enemy if they're over eachother
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("hit");
            direction.x *= -1;
        }

        //if player jumps on enemy from above, destroy, else remove 1 health
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.y >= transform.position.y)
            {
                audioManager.PlayAudio(deathSound);
                Destroy(this.gameObject);
            }
            else {
                collision.gameObject.GetComponent<CharacterController2D>().health--;
            }
        }
    }
}


