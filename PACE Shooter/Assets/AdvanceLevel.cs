using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceLevel : MonoBehaviour {
	int BossLeft = 2;
	bool killedAllBoss = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
		BossLeft = enemies.Length;
		Debug.Log(BossLeft + "Left");

	}
}
