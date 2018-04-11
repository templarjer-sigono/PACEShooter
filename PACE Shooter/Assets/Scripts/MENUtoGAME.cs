using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUtoGAME : MonoBehaviour {

	public string levelName;

	// Use this for initialization
	void Start () {
		int SceneNbr = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (1);
		}
	}
}
