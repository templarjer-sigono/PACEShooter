using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float forceValue;
	public float MaxSpeed;
	public float decreasingSpeed;
	private Rigidbody2D rigidbody2D = null;
	public GameObject bulletCandidate;
	private float bulletOffset = 0.6f;
	public GameObject Player;
	public float bulletVelocity = 5f;
	public GameObject bullet;
	private int deathcount = 0;

	// Use this for initialization
	void Start () {
		rigidbody2D = this.GetComponent<Rigidbody2D> ();
	}
	float speed = 6;
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col)
	{
		//	deathcount = deathcount +1
		if ((col.tag == "EBLTS")) {
			Debug.Log ("asdasd");
		}
		}
	void Update () {

		Vector2 force2D = Vector2.zero;

		if (Input.GetKey (KeyCode.W)) {
			//this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
			force2D.y += forceValue;
		}
		if (Input.GetKey (KeyCode.S)) {
			//this.transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
			force2D.y -= forceValue;
		}
		if (Input.GetKey (KeyCode.A)) {
			force2D.x -= forceValue;
		}
		if (Input.GetKey (KeyCode.D)) {
			force2D.x += forceValue;
		}
		if (force2D != Vector2.zero) {
			rigidbody2D.AddForce (force2D);
			float speed = rigidbody2D.velocity.magnitude;
			if (speed > MaxSpeed) {
				speed = MaxSpeed;
			}
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
		} else {
			float speed = rigidbody2D.velocity.magnitude;
			speed -= decreasingSpeed * Time.deltaTime;
			if (speed < 0) {
				speed = 0;
			}
			rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
		}

		rigidbody2D.AddForce (force2D);

		if (Input.GetButtonDown ("Fire1")) {
			Vector3 worldMousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 direction = (Vector2)((worldMousePos - transform.position));
			direction.Normalize ();
			// Creates the bullet locally
			GameObject bullet = (GameObject)Instantiate (
				                    bulletCandidate,
				                    transform.position + (Vector3)(direction * 0.5f),
				                    Quaternion.identity);
			// Adds velocity to the bullet
			bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletVelocity;
		}
	}

	}

