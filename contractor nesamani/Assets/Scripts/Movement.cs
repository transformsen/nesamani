using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public float moveSpeed = 10f;
	public GameObject charecter;
	private Rigidbody2D rb;
	private float screenWidth;
	
    void Start(){
		screenWidth = Screen.width;
		rb = charecter.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
		 MobileMove();
    }
	
	void MobileMove(){
		int i =0;
		while(i< Input.touchCount){
			if(Input.GetTouch(i).position.x > screenWidth/2){
				RunCharecter(1.0f);
			}
			if(Input.GetTouch(i).position.x < screenWidth/2){
				RunCharecter(-1.0f);
			}
			++i;
		}
	}
	
	void RunCharecter(float horizontalInput){
		rb.AddForce(new Vector2(horizontalInput * Time.deltaTime * moveSpeed, 0 ));
	}
	
	void FixedUpdate(){
			
		//MoveForFixed();
		#if UNITY_EDITOR
		RunCharecter(Input.GetAxis("Horizontal"));
		#endif		
 
	}
}
