using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathSFX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AkSoundEngine.PostEvent ("Enemy_boss_death", gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
