using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FontSizeIncrease : MonoBehaviour {

	Text m_Text;
	public GameObject GameOver;
	int fsize= 10;

	// Use this for initialization
	void Start () {
		m_Text = GetComponent<Text>();
		m_Text.fontSize = fsize;
	}
	
	// Update is called once per frame
	void Update () {

		if (GameOver.activeInHierarchy == true && fsize < 250) {
			fsize += 5;
		}
	}
}
