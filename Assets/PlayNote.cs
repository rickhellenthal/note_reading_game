using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
	    audioSource = GetComponent<AudioSource>();
	    audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        audioSource.Play();
    }
}
