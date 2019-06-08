using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static int health = 3;
	public static int save = 0;
	public static int coin = 0;
	public static bool gameOver = false;
   // Update is called once per frame
    void Update()
    {
        if(health <= 0){
			gameOver = true;
		}else{
			gameOver = false;
		}
    }
}
