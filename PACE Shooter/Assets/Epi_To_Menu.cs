using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Epi_To_Menu : MonoBehaviour {
	private int health = 16; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		AkSoundEngine.SetRTPCValue ("Player_health", health);
		if (Input.GetKey(KeyCode.Return)) {
			AkBankManager.UnloadBank ("Soundbank");
			SceneManager.LoadScene ("Menu");
		}
	}
}
