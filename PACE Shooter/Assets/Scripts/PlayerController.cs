using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//PLAYER MOVEMENT
	public float forceValue;
	public float MaxSpeed;
	public float decreasingSpeed;

	//BULLET AND COLLISION
	private Rigidbody2D rigidbody2Dp = null;
	public GameObject bulletCandidate;

	//private float bulletOffset = 0.6f;
	public GameObject Player;
	public float bulletVelocity = 5f;
	public GameObject bullet;

	//CAMERA
	public Camera GameCamera;
	public GameObject OverText;
	public float CameraShakeDuration;
	public float CameraShakeStrength;
	private float OrthoSizeA = 6f;
	private float OrthoSizeb = 4f;
	private float OrthoSizec = 0.02f;
	private float SmoothZoomt = 5f;

	//INJURY AND DEATHS
	private bool DeathZoom = false;
	private float elapsed = 0.0f;
	private float injurelap = 0.0f;
	public int health = 5;
	private bool injuredzoom = false;
	private bool DeathCheck = false;

	//FOOTSTEP
	public float FootStepRatePlay;
	public AudioSource PlayerAudioSource;
	public AudioClip[] FootSteps;
	public float Timer;


	// Use this for initialization
	void Start () {
		rigidbody2Dp = this.GetComponent<Rigidbody2D> ();
	}
	//float speed = 6;
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D col)
	{
		
	
		//	deathcount = deathcount +1
		if ((col.tag == "EBLTS")) {
			health -= 1;
			if ((health > 0)) {
				GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrength);
				injuredzoom = true;
			}
				else {
					DeathZoom = true;
					DeathCheck = true;
				}
			}
		}

	void FixedUpdate () {

		if (injuredzoom){
			injurelap += Time.deltaTime / 6f;
			GameCamera.orthographicSize = Mathf.Lerp (OrthoSizeA,OrthoSizeb, injurelap);
			if (injurelap >= 1.0f) {
					injuredzoom = false;
				}
			}
			
		if (DeathZoom) {
			injuredzoom = false;
			rigidbody2Dp.bodyType = RigidbodyType2D.Static;
			elapsed += Time.deltaTime / SmoothZoomt * 1.4f ;

			GameCamera.orthographicSize = Mathf.Lerp (OrthoSizeb, OrthoSizec, elapsed);
		
			if (Input.GetKey (KeyCode.Return)) {
				SceneManager.LoadScene (0);
			}

			OverText.SetActive(true);
			if (elapsed >= 1.0f) {
				DeathZoom = false;
			}
		}

		if (DeathCheck != true) {
			Vector2 force2D = Vector2.zero;

			if (Input.GetKey (KeyCode.W)) {
				//this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
				force2D.y += forceValue;
				if (Time.time > Timer) {
					Timer = Time.time + 1 / FootStepRatePlay;
					FootStepRandomize ();
				}
			}
			if (Input.GetKey (KeyCode.S)) {
				//this.transform.position += new Vector3 (0, -speed * Time.deltaTime, 0);
				force2D.y -= forceValue;
				if (Time.time > Timer) {
					Timer = Time.time + 1 / FootStepRatePlay;
					FootStepRandomize ();
				}
			}
			if (Input.GetKey (KeyCode.A)) {
				force2D.x -= forceValue;
				if (Time.time > Timer) {
					Timer = Time.time + 1 / FootStepRatePlay;
					FootStepRandomize ();
				}
			}
			if (Input.GetKey (KeyCode.D)) {
				force2D.x += forceValue;
				if (Time.time > Timer) {
					Timer = Time.time + 1 / FootStepRatePlay;
					FootStepRandomize ();
				}
			}
			if (force2D != Vector2.zero) {
				rigidbody2Dp.AddForce (force2D);
				float speed = rigidbody2Dp.velocity.magnitude;
				if (speed > MaxSpeed) {
					speed = MaxSpeed;
				}
				rigidbody2Dp.velocity = rigidbody2Dp.velocity.normalized * speed;
			} else {
				float speed = rigidbody2Dp.velocity.magnitude;
				speed -= decreasingSpeed * Time.deltaTime;
				if (speed < 0) {
					speed = 0;
				}
				rigidbody2Dp.velocity = rigidbody2Dp.velocity.normalized * speed;
			}

			rigidbody2Dp.AddForce (force2D);
			if (DeathCheck) {
				rigidbody2Dp.mass = 1000f;
				Debug.Log ("MASS INCREASED");
			}
			if (Input.GetButtonDown ("Fire1")) {
				Vector3 worldMousePos = Vector3.one;
				Ray _mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (_mouseRay,out hit)) {
					worldMousePos = hit.point;
					Debug.Log (worldMousePos);
				}
				float midPoint = (transform.position - Camera.main.transform.position).magnitude * 44f;

				//worldMousePos.z = Camera.main.farClipPlane;
				Vector2 direction = (Vector2)((_mouseRay.origin + _mouseRay.direction * midPoint));
				//Debug.Log (worldMousePos);
				direction.Normalize ();
				// Creates the bullet locally
				GameObject bullet = (GameObject)Instantiate (
					                    bulletCandidate,
					                    transform.position + (Vector3)(direction * 1f),
					                    Quaternion.identity);
				// Adds velocity to the bullet
				bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletVelocity;
				//bullet.GetComponent<Rigidbody2D> ().AddForce = worldMousePos;
			}
		}


			

	}

	void FootStepRandomize()
	{
		AudioClip SoundToPlay = FootSteps [Random.Range (0, FootSteps.Length)];
		PlayerAudioSource.PlayOneShot (SoundToPlay);
	}

	}

