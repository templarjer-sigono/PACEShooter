using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUtoGAME : MonoBehaviour {

	public string levelName;
	int SceneNbr;
	// Use this for initialization
	void Start () {
		SceneNbr = SceneManager.GetActiveScene ().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Return)) {
			SceneManager.LoadScene (SceneNbr + 1);
		}
	}
}
