using UnityEngine;
using System.Collections;

public class Mushroom : MovementBase {

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("hit");
            direction.x *= -1;
        }

        if (collision.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);

            collision.gameObject.GetComponent<CharacterController2D>().health = 2;
        }
    }

}
