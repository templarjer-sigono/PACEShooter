using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bank_destroyer : MonoBehaviour {
	int BossLeft;
	public GameObject Thisone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");

		BossLeft = enemies.Length;
		if (BossLeft < 1 || Input.GetKeyDown (KeyCode.P)) 
		{
			Destroy (Thisone);
		}
	}
}
