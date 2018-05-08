using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wwise_destroy : MonoBehaviour {
	public GameObject WWISEPARENT;
	int BossLeft;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
		BossLeft = enemies.Length;
		if (BossLeft < 1 || Input.GetKeyDown (KeyCode.F)) 
		{
			Destroy (WWISEPARENT);
			Debug.Log ("yidi");
		}
	}
}
