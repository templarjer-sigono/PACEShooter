using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
	
	bool Cmon = false;

	int BossLeft;

	[SerializeField]
	private List<GameObject> stages;
	private GameObject _currentstage;
	[SerializeField]
	private int stage;


	public bool EnemyBulletSwitch;

	private void Awake()
	{
//		stage = PlayerPrefs.GetInt("Stage", 0);
/*		if (stage >= stages.Count)
		{
			stage = 0;
		}
*/
	
		LoadLevel ();
		Cmon = true;
/*		GameObject.Instantiate(stages[stage], transform);
		StartCoroutine(ChangeLevel()); 
*/
	}

/*	private IEnumerator ChangeLevel()
	{
		yield return new WaitForSeconds(5.0f);
		PlayerPrefs.SetInt("Stage", stage + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
*/

	void Update () 
	{

	

		if (Cmon)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
			BossLeft = enemies.Length;
			if (Input.GetKeyDown (KeyCode.T)){
				Debug.Log(BossLeft);
			}

			if (BossLeft < 1 || Input.GetKeyDown (KeyCode.P)) 
			{
				stage++;
				Debug.Log ("No Boss Detected");
				if (stage < 3) 
				{
					GameObject.Destroy (_currentstage);

					Debug.Log ("Level Now Changed to: " + stage);
					//_currentstage++;
					LoadLevel();
				}
				else
				{		
					SceneManager.LoadScene (2);
					Debug.Log ("Scene Changed");
				}
			}
		}
	} 

	void LoadLevel ()
	{
		_currentstage = GameObject.Instantiate (stages [stage], transform);
						
	}
					

}
