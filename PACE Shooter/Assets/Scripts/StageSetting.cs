/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetting : MonoBehaviour {

	public List<StageData> datas;

	private void Awake()
	{
		foreach (var data in datas)
		{
			var stageData = GameObject.Instantiate(data.prefab, transform);
			stageData.transform.localPosition = data.position;
			//stageData.transform.rotation = Quaternion.Euler(data.rotation);
			stageData.transform.localScale = data.scale;
		}
	}
}

*/
