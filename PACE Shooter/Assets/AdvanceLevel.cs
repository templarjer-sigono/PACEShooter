using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceLevel : MonoBehaviour {
	int BossLeft = 2;
	int SceneNbr ;
	int SceneTotal;
	// Use this for initialization
	void Start () {
		SceneNbr = SceneManager.GetActiveScene ().buildIndex;
		SceneTotal = SceneManager.sceneCount;
		Debug.Log ("SceneTotal" + SceneTotal + "SceneNbr" + SceneNbr);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
		BossLeft = enemies.Length;
		if (BossLeft < 1) 
		{
			if (SceneTotal >= SceneNbr) 
			{
				SceneManager.LoadScene (SceneNbr + 1);
			}
			else
			{		
				SceneManager.LoadScene (0);
			}
		}
	}
}
