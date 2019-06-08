using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject){
			
			if(collider.gameObject.tag == "Ground"){
				if(!GameManager.gameOver){
					GameManager.save++; 
				}
			}
			if(collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Player"){
				Destroy(gameObject, 0.4f);
			}									
		}		
	}
}
