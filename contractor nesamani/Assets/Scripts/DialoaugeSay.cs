using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoaugeSay : MonoBehaviour
{
    public AudioClip[] hurtClips;	 
	
	AudioSource playerAudio;  
    	 
	 void Awake(){
		 playerAudio = GetComponent<AudioSource>();
		 PlayAudio();
	 }

    public void PlayAudio(){
		AudioClip hurtClip = hurtClips[Random.Range(0, hurtClips.Length)];
		playerAudio.clip = hurtClip;
		playerAudio.Play();
	}
}
