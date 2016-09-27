using UnityEngine;
using System.Collections;

public class Enemy : MovementBase {

    //destroy player/enemy if they're over eachother
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("hit");
            direction.x *= -1;
        }

        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.transform.position.y >= transform.position.y)
            {
                Destroy(this.gameObject);
            }
            else {
                collision.gameObject.GetComponent<CharacterController2D>().health--;
                collision.gameObject.GetComponent<CharacterController2D>().poweredUp = false;
            }
        }
    }
}


