using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	public float moveSpeed = 10f;
	private Rigidbody2D rb;
	private Vector3 m_Velocity = Vector3.zero;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	
	float horizontalMove = 0f;
	private float deltaX, deltaY;
	private float screenWidth;
    // Start is called before the first frame update
	
	void Start(){
		screenWidth = Screen.width;
	}
	
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
		//TouchMove();
		//MobileMove();
    }
	
	void Move(){
		horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
	}
	
	void TouchMove(){
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
			switch(touch.phase){
				case TouchPhase.Began:
					deltaX = touchPos.x - transform.position.x;
					//deltaY = touchPos.y - transform.position.y;
					break;
				case TouchPhase.Moved:
					rb.MovePosition(new Vector2(touchPos.x - deltaX, transform.position.y));
					break;
				case TouchPhase.Ended:
					rb.velocity = Vector2.zero;
					break;
			}
		}
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
		Debug.Log("RunCharecter"+horizontalInput);
	}
	
	void FixedUpdate(){
			
		//MoveForFixed();
		#if UNITY_EDITOR
		RunCharecter(Input.GetAxis("Horizontal"));
		#endif		
 
	}
	
	void MoveForFixed(){
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(horizontalMove * Time.fixedDeltaTime * 10f, rb.velocity.y);
		// And then smoothing it out and applying it to the character
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
	}
}
