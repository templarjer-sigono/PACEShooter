using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO;
	public Animator _ShootAnim;
	public bool EnemyShootSwitch;
	int EnemyDeaths;
	private int health;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireEnemyBullet", 0.5f, 1f);
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
	
		health = GameObject.Find("playerishere").GetComponent<PlayerController>().health;
		PlayShootAnim ();
		if (health > 0){
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
//			Debug.Log ("ENEMY = " + EnemyDeaths);
		}
			
	}
}
