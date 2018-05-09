using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
	
	bool Cmon = false;

	int BossLeft;

	[SerializeField]
	private List<GameObject> stages;
	//private GameObject _currentstage;
	[SerializeField]
	private int stage;
	private int SceneNbr;


	public bool EnemyBulletSwitch;

	private void Awake()
	{
//		stage = PlayerPrefs.GetInt("Stage", 0);
/*		if (stage >= stages.Count)
		{
			stage = 0;
		}
*/
	
		Cmon = true;
/*		GameObject.Instantiate(stages[stage], transform);
		StartCoroutine(ChangeLevel()); 
*/
	}



	/*private IEnumerator ChangeLevel()
	{
		yield return new WaitForSeconds(5.0f);
		PlayerPrefs.SetInt("Stage", stage + 1);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
*/

	void Update () 
	{
		SceneNbr = SceneManager.GetActiveScene().buildIndex;
	

		if (Cmon)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
			BossLeft = enemies.Length;
			if (Input.GetKeyDown (KeyCode.T)){
				Debug.Log(BossLeft);
			}

			if (BossLeft < 1 || Input.GetKeyDown (KeyCode.P)) 
			{
				AkBankManager.UnloadBank ("Soundbank");
					Debug.Log ("Level Now Changed to: " + stage);
					//_currentstage++;
			
					SceneManager.LoadSceneaww (SceneNbr+1);
				}
			}
		}


	void LoadLevel ()
	{
		//_currentstage = GameObject.Instantiate (stages [stage], transform);
						
	}
					

}
