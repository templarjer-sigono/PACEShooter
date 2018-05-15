using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUtoGAME : MonoBehaviour {

	public string levelName;
	private int health = 16;
	// Use this for initialization
	void Start () {
		int SceneNbr = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		AkSoundEngine.SetRTPCValue ("Player_health", health);
		if (Input.GetButtonDown("Fire1")) {
			AkBankManager.UnloadBank ("Soundbank");
			SceneManager.LoadScene (1);
		}
	}
}
