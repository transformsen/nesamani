using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boundries : MonoBehaviour
{
	private Vector2 secrenBounds;
	private float objectWidth;
	private float objectHeight;
	
    // Start is called before the first frame update
    void Start()
    {
        secrenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x/2;
		objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(viewPos.x, secrenBounds.x + objectWidth, secrenBounds.x*-1-objectWidth);
		viewPos.y = Mathf.Clamp(viewPos.y, secrenBounds.y + objectHeight, secrenBounds.y*-1-objectHeight);
		transform.position = viewPos;
    }
}
