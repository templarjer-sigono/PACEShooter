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
	public float bulletVelocity = 0.001f;
	public GameObject bullet;

	//CAMERA
	public Camera GameCamera;
	public GameObject OverText;
	public float CameraShakeDuration;
	public float CameraShakeStrength;
	private float OrthoSizeA = 13.9f;
	private float OrthoSizeb = 10f;
	private float OrthoSizec = 999f;
	private float SmoothZoomt = 10f;

	//BETWEEN CAMERA SHAKE
	private float BetweenCameraShake = 0.65f;
	private float Camtimestamp;
	private bool CanCamShake = true;

	//INJURY AND DEATHS
	private bool DeathZoom = false;
	private float elapsed = 0.0f;
	private float injurelap = 0.0f;
	public int health = 18;


	private bool injuredzoom = false;
	private bool DeathCheck = false;

	//FOOTSTEP
	/*
	public AudioSource PlayerAudioSource;
	public AudioClip[] FootSteps; */
	public float Timer;
	public float FootStepRatePlay;
	public float m_StepCycle, m_NextStep;
   
	//Fire
	public float speed = 0.3f;
	public float force = 10f;
	public GameObject bulletPrefab;
	public GameObject gunEnd;
	public bool canShoot = true;
	public float timeBetweenShots = 0.1f;
	private float timestamp;
	private bool heartbeat_switch = false;



	/*Perspktif Pointkliking
	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
		Ray ray = Camera.main.ScreenPointToRay(screenPosition);
		Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
		float distance;
		xy.Raycast(ray, out distance);
		return ray.GetPoint(distance);
	}
*/

	// Use this for initialization
	void Start () {
		rigidbody2Dp = this.GetComponent<Rigidbody2D> ();
	
	

	}
	//float speed = 6;
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D col)
	{
		
	
		//	deathcount = deathcount +1
		if ((col.tag == "EBLTS") && CanCamShake) {
			health -= 1;

			if ((health > 0)) {
				if (CanCamShake) {
					AkSoundEngine.PostEvent ("Player_hurt", gameObject);
					GameCamera.transform.DOShakePosition (CameraShakeDuration, CameraShakeStrength);
					CanCamShake = false;
				}
				if ((health < 10)) {
					AkSoundEngine.SetRTPCValue ("Player_health", health);
					injuredzoom = true;
					if (!heartbeat_switch) {
						AkSoundEngine.PostEvent ("Player_heartbeat", gameObject);
						heartbeat_switch = true;
					}
				}
			}
				else {
					DeathZoom = true;
					DeathCheck = true;
				}
			}
		}

	void FixedUpdate () {

	
		if (Time.time >= Camtimestamp) {
			CanCamShake = true;
			Camtimestamp = Time.time + BetweenCameraShake;
		}

		if (injuredzoom){
			injurelap += Time.deltaTime / 3f;
			GameCamera.fieldOfView = Mathf.Lerp (OrthoSizeA,OrthoSizeb, injurelap*1.4f);
			if (injurelap >= 2f) {
					injuredzoom = false;
				}
			}
			
		if (DeathZoom) {
			injuredzoom = false;
			rigidbody2Dp.bodyType = RigidbodyType2D.Static;
			elapsed += Time.deltaTime / SmoothZoomt * 1.4f ;
			GameCamera.fieldOfView = Mathf.Lerp (OrthoSizeb, OrthoSizec, elapsed);
		

		
			if (Input.GetKey (KeyCode.Return)) {
				//AkBankManager.UnloadBank ("Soundbank");
				SceneManager.LoadScene (0);
			}

			OverText.SetActive(true);

		}

		if (DeathCheck != true) {
			Vector2 force2D = Vector2.zero;





			if (Input.GetKey (KeyCode.W)) {
				force2D.y += forceValue;

			}
			if (Input.GetKey (KeyCode.S)) {
				force2D.y -= forceValue;

			}
			if (Input.GetKey (KeyCode.A)) {
				force2D.x -= forceValue;

			}
			if (Input.GetKey (KeyCode.D)) {
				force2D.x += forceValue;
				/*if (Time.time > Timer) {
					Timer = Time.time + 1 / FootStepRatePlay;
					FootStepRandomize ();
				} */
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




			//PlayerShoot


			if (Time.time >=timestamp && Input.GetButtonDown("Fire1")&&canShoot) {
				AkSoundEngine.PostEvent ("Player_shoot", gameObject);
				Vector3 worldMousePos = Vector3.one;
				Ray _mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (_mouseRay,out hit)) {
					worldMousePos = hit.point;
					Debug.Log (worldMousePos);
				}

				float midPoint = (transform.position - Camera.main.transform.position).magnitude * 10000000000000f;

				//worldMousePos.z = Camera.main.farClipPlane;
				Vector2 direction = (Vector2)((_mouseRay.origin + _mouseRay.direction * midPoint));
				//Debug.Log (worldMousePos);
				direction.Normalize ();
				// Creates the bullet locally
				GameObject bullet = (GameObject)Instantiate (
					bulletCandidate,
					transform.position + (Vector3)(direction * 0.5f),
					Quaternion.identity);
				// Adds velocity to the bullet
				bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletVelocity / 1.2f;

				timestamp = Time.time + timeBetweenShots;
			}
			/*
			if (force2D.x != 0 || force2D.y != 0) {

				AkSoundEngine.PostEvent ("Play_Footsteps", gameObject);

			} */

		}


			

	}
		

	/*void FootStepRandomize()
	{
		AudioClip SoundToPlay = FootSteps [Random.Range (0, FootSteps.Length)];
		PlayerAudioSource.PlayOneShot (SoundToPlay);
	}
*/
	}

