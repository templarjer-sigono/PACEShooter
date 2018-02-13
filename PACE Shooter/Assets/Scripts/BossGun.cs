using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {
	public GameObject BossBulletGO;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("FireBossBullet", 0.1f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FireBossBullet()
	{
		GameObject playerishere = GameObject.Find ("playerishere");

		if (playerishere != null){
		GameObject bullet = (GameObject)Instantiate(BossBulletGO);
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
