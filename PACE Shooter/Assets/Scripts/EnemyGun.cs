using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO;
	public Animator _ShootAnim;
	int EnemyDeaths;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", 0.4225f, 0.845f);
	}

	private void PlayShootAnim(){
		_ShootAnim.Play ("EnemyShootAnim");
	//	Debug.Log ("Anim Triggered!");
	}

	// Update is called once per frame
	void Update () {
		
	}
	void FireEnemyBullet()
	{
		GameObject playerishere = GameObject.Find ("playerishere");
		PlayShootAnim ();
		if (playerishere != null){
		GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
		bullet.transform.position = transform.position;
			Vector2 direction = playerishere.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if((col.tag == "Bullets")){
			Destroy(gameObject);
			EnemyDeaths = EnemyDeaths + 1;
			Debug.Log ("ENEMY = " + EnemyDeaths);
		}
			
	}
}
