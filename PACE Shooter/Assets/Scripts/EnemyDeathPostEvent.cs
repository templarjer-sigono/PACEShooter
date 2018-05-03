using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathPostEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("EnemyDeathSFX", gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
