using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	// Use this for initialization
	void Start ()
	{
		GameObject.FindObjectOfType<MusicManager> ();
		if (musicManager) {
			float volume = PlayerPrefsManager.GetMasterVolume();
			musicManager.SetVolume(volume);
		} else {
			Debug.LogWarning("Nomusic manager found in Start scene, can't set volume");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
