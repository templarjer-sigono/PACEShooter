using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour {
	public GameObject prefab;
	public List<Vector3> minions;
	// Use this for initialization

	void Awake () {

		foreach (var item in minions) {
			var minion = GameObject.Instantiate (prefab, transform);
			minion.transform.localPosition = item;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
