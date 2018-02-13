using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO;
	public Animator _ShootAnim;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("FireEnemyBullet", 0.423f, 0.846f);
	}

	private void PlayShootAnim(){
		_ShootAnim.Play ("EnemyShootAnim");
		Debug.Log ("Anim Triggered!");
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
		}
	}
}
