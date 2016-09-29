using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {

    public GameObject fireFlower;
    public GameObject muzzle;
	public float upSpead;
	public float jumpSpead;
	public bool jumping = false;
	public bool grounded = false;
	public string sidesHit = "none";
	public Vector2 down;
	public Vector2 sides;
	public Vector2 sideLeft;
	public float skinWidth = 0.1f;
	public float InitalAcceleration = 50;
	public float airspeed = 50;
	public bool maxSpeed = false;
    public int health = 1;
    public float firingTime;
    public float firingRate = 1.5f;

    public Material health1;
    public Material health2;
    public Material health3;
    public MeshRenderer meshRenderer;

	Vector2 start;
	RaycastHit2D hit;

	void Start() {
        this.GetComponent<Material>();
    }

	void Update () {
	//Basic ground checking code with Physics2d raycasting
		sideLeft = transform.position;
		sideLeft.x = transform.position.x - transform.localScale.x / 2 - 0.1f;
		sides = transform.position;
		sides.x = transform.position.x + transform.localScale.x / 2 + 0.1f;
		start = transform.position;
		start.y = transform.position.y - transform.localScale.y/2f - 0.1f;
		Debug.DrawRay (start, -Vector2.up);
		Debug.DrawRay (new Vector2(start.x - transform.localScale.x/2, start.y), -Vector2.up);
		Debug.DrawRay (new Vector2(start.x + transform.localScale.x/2, start.y), -Vector2.up);
		Debug.DrawRay (sides, Vector2.right);
		Debug.DrawRay (sideLeft, -Vector2.right);

		if (Physics2D.Raycast (start, -Vector2.up, skinWidth).collider != null || Physics2D.Raycast (new Vector2(start.x + transform.localScale.x/2, start.y), -Vector2.up, skinWidth).collider != null || Physics2D.Raycast (new Vector2(start.x - transform.localScale.x/2, start.y), -Vector2.up, skinWidth).collider != null) {
						grounded = true;
				} else {
			grounded = false;
				}

	
		if (Input.GetKeyUp(KeyCode.A) && grounded == true) {
			//Detect when certain keys are released to reset velocity
			//Reset the velocity to a number close to 0 to make a sudden stop, but ease out to fell smoother
			GetComponent<Rigidbody2D>().velocity = new Vector2(-2,0);
		}
		if (Input.GetKeyUp(KeyCode.D) && grounded == true) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(2,0);
		}
		//Jumping Trigger
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(grounded == true){
			jumping = true;
				//Add the Initial Accleration to make the player shoot up, and then slow down, then fall
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,InitalAcceleration));

			}
				}
		if (Input.GetKeyUp (KeyCode.Space)) {
			jumping = false;
		}
		if (Input.GetKey (KeyCode.Space)) {
			if(jumping == true){
				//Detect if speed limit is reached, and then fall back down
			if(GetComponent<Rigidbody2D>().velocity.y >=10){
				jumping = false;
				}
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpSpead * Time.deltaTime));


				}
			}

		Move ();

        if (health <= 0) {
            Destroy(this.gameObject);
        }

        if (health == 3) {
            meshRenderer.material = health3;
            fire();
            //transform.localScale = new Vector3(0, 0.5f, 0);
        }
        if (health == 2) {
            meshRenderer.material = health2;
            //transform.localScale = new Vector3(0, 0.5f, 0);
        }
        if (health == 1) {
            meshRenderer.material = health1;
            //transform.localScale = new Vector3(0, -0.5f, 0);
        }



	}
	void Move(){
		//Move in air code
		if (Input.GetAxisRaw ("Horizontal") < 0 && grounded == false && maxSpeed == true) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(airspeed * Time.deltaTime,0));
				}
		else if (Input.GetAxisRaw ("Horizontal") > 0 && grounded == false && maxSpeed == true) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-airspeed * Time.deltaTime,0));
		}

		//Move Left/Right Code
		if (GetComponent<Rigidbody2D>().velocity.x >= 9 || GetComponent<Rigidbody2D>().velocity.x <= -9) {
						maxSpeed = true;
				} else {
			if(maxSpeed == true){
				maxSpeed = false;
			}
				}
		
		if (Input.GetAxisRaw ("Horizontal") < 0 && sidesHit != "left") {

            muzzle.transform.eulerAngles = new Vector3(0, 180, 0);

			if (maxSpeed == false && grounded == false) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-airspeed * Time.deltaTime,0));

			}else if(maxSpeed == false){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(-upSpead * Time.deltaTime,0));
				}
			}
		if (Input.GetAxisRaw ("Horizontal") > 0 && sidesHit != "right") {

            muzzle.transform.eulerAngles = new Vector3(0, 0, 0);

            if (maxSpeed == false && grounded == false) {
				GetComponent<Rigidbody2D>().AddForce(new Vector2(airspeed * Time.deltaTime,0));
				
			}else if(maxSpeed == false){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(upSpead * Time.deltaTime,0));
			}
		}

	}

    void fire() {
        if (Input.GetMouseButtonDown(0) && Time.time> firingTime) {
            Instantiate(fireFlower, muzzle.transform.position, muzzle.transform.rotation);
            firingTime = Time.time + firingRate;
        }
    }
}
