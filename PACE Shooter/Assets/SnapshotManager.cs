using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SnapshotManager : MonoBehaviour {

	public AudioMixerSnapshot Stage1S_;
	public AudioMixerSnapshot Stage2S_;
	public AudioMixerSnapshot Stage3S_;
	public AudioMixerSnapshot Stage4S_;
	public AudioMixerSnapshot Stage42S_;
	public AudioMixerSnapshot Stage5S_;
	public BoxCollider2D Stage1C_;
	public BoxCollider2D Stage2C_;
	public BoxCollider2D Stage3C_;
	public BoxCollider2D Stage4C_;
	public BoxCollider2D Stage42C_;
	public BoxCollider2D Stage5C_;
	public float SmoothTimer;

	void Awake ()
	{
		Stage1S_.TransitionTo(0f);
	}

	public void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.tag == "SnapshotStage1") {
			//Debug.Log ("Snapshot1 Activated!");
			Stage1S_.TransitionTo (SmoothTimer);
		}
		if (coll.tag == "SnapshotStage2") {
			//Debug.Log ("Snapshot2 Activated!");
			Stage2S_.TransitionTo (SmoothTimer);
		}
		if (coll.tag == "SnapshotStage3") {
			//Debug.Log ("Snapshot3 Activated!");
			Stage3S_.TransitionTo (SmoothTimer);
		}
		if (coll.tag == "SnapshotStage4") {
			//Debug.Log ("Snapshot4 Activated!");
			Stage4S_.TransitionTo (SmoothTimer);
		}
		if (coll.tag == "SnapshotStage42") {
			//Debug.Log ("Snapshot4 Activated!");
			Stage42S_.TransitionTo (SmoothTimer);
		}
		if (coll.tag == "SnapshotStage5") {
			//Debug.Log ("Snapshot5 Activated!");
			Stage5S_.TransitionTo (1f);
		}
	}

}
