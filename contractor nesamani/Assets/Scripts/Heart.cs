using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject){
			if(!GameManager.gameOver){				
				if(collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Player"){
					Destroy(gameObject, 0.1f);
				}
			}									
		}		
	}
}
