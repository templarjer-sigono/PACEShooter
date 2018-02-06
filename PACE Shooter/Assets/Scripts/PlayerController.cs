using UnityEngine;
using System.Collections;
using DG.Tweening;

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
	public Camera GameCamera;
	public float CameraShakeDuration;
	public float CameraShakeStrength;
	private float OrthoSizeA = 3f;
	private float OrthoSizeB = 0.02f;
	private float SmoothZoomt = 5f;
	private bool DeathZoom = false;
	private float elapsed = 0.0f;
	private int health = 1;
	private bool DeathCheck = false;
	public BoxCollider2D boxcollider;


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
			
			if (health != 0) {
				health -= 1;
				GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrength);
			}
				else
			{	DeathZoom = true;
				DeathCheck = true;
			}
		}
		}

	void FixedUpdate () {

		if (DeathZoom) {
			elapsed += Time.deltaTime / SmoothZoomt;
			GameCamera.orthographicSize = Mathf.Lerp (OrthoSizeA, OrthoSizeB, elapsed);
			if (elapsed >= 1.0f) {
				DeathZoom = false;
			}
		}

		if (DeathCheck != true) {
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
			if (DeathCheck) {
				rigidbody2D.mass = 1000f;
				Debug.Log ("MASS INCREASED");
			}
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
	}

