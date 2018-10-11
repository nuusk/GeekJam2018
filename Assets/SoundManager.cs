using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource efxSource;
	public AudioSource musicPsychedelicRun;
	public AudioSource musicForgeOfTime;

	public AudioSource ghastSource;
	public static SoundManager instance = null;

	private void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void PlaySingle(AudioClip clip) {
		efxSource.clip = clip;
		efxSource.Play();
	}

	public void RandomizeSfx (params AudioClip[] clips) {
		int randomIndex = Random.Range(0, clips.Length);
		efxSource.clip = clips[randomIndex];
		efxSource.Play();
	}

	public void enterForge() {
		musicForgeOfTime.Play();
	}

	public void ghastScream(AudioClip clip) {
		ghastSource.clip = clip;
		ghastSource.Play();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
