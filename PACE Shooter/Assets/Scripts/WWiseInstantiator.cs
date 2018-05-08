using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WWiseInstantiator : MonoBehaviour {

	public GameObject INSTA;

	// Use this for initialization
	void Start () {
		Instantiate (INSTA);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
