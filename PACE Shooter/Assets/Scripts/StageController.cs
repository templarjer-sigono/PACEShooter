using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
	
	bool Cmon = false;

	[SerializeField]
	private List<GameObject> stages;

	[SerializeField]
	private int stage;

	private void Awake()
	{
		stage = PlayerPrefs.GetInt("Stage", 0);
		if (stage >= stages.Count)
		{
			stage = 0;
		}
		GameObject.Instantiate(stages[stage], transform);

		if (!Cmon){
			Cmon = true;
		}

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

	/*void Update () 
	{
		if (Cmon)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("EnemyBoss");
			BossLeft = enemies.Length;

			if (BossLeft < 1) 
			{
				if (stage <= stages.Count) 
				{
					GameObject.Instantiate(stages[stage], transform);
					PlayerPrefs.SetInt("Stage", stage + 1);
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{		
					SceneManager.LoadScene (0);
				}
			}
		}
	} */

}
