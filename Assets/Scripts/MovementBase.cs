using UnityEngine;
using System.Collections;

public class MovementBase : MonoBehaviour {

    public Vector3 direction = new Vector3(-1, 0, 0);

    public float moveSpeed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * Time.deltaTime);
	}

    public virtual void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Wall") {
            //Debug.Log("hit");
            direction.x *= -1;
        }
    }
}
