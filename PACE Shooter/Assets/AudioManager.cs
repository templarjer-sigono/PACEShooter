using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {


	public AudioMixerSnapshot StageStart;
	// Use this for initialization
	void Start () {
		StageStart.TransitionTo (0F);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
