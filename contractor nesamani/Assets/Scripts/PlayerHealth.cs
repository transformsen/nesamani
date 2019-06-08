using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public AudioClip[] hurtClips;	 
	public AudioClip hammerClips;
	public AudioClip heartClips;
	public AudioClip coinClips;
	
	AudioSource playerAudio;  
	ParticleSystem hitParticles;
    	 
	 void Awake(){
		 playerAudio = GetComponent<AudioSource>();
		 hitParticles = GetComponentInChildren<ParticleSystem>();
	 }
	    
	void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject){
			if(collider.gameObject.tag == "Hammer"){
				if(!GameManager.gameOver){
					GameManager.health--;
					hitParticles.Play();
					playerAudio.clip = hammerClips;
					playerAudio.Play();
					
					StartCoroutine(HurtingSound());
				}
				
			}else if(collider.gameObject.tag == "Heart"){
				if(!GameManager.gameOver){
					GameManager.health++;				
					playerAudio.clip = heartClips;
					playerAudio.Play();
				}
			}else if(collider.gameObject.tag == "Coin"){
				if(!GameManager.gameOver){
					GameManager.coin++;	
					playerAudio.clip = coinClips;
					playerAudio.Play();					
				}
			}
		}
	}
	
	IEnumerator HurtingSound(){
		yield return new WaitForSeconds(0.3f);
		AudioClip hurtClip = hurtClips[Random.Range(0, hurtClips.Length)];
		playerAudio.clip = hurtClip;
		playerAudio.Play();		
	}
}
