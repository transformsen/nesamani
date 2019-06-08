using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
	public Image[] healthImages;
	public Text saveText;	
	public Text coinText;	
	public GameObject gameOver;
	public GameObject startWindow;
	public static bool isStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		HealthStatus();
        SaveUpdate();
		CheckForGameOver();
		Back();
    }
	
	void HealthStatus(){
		for(int i=0; i<healthImages.Length; i++)
        {
			if(GameManager.health < (i+1)){
				healthImages[i].gameObject.SetActive(false);
			}else{
				healthImages[i].gameObject.SetActive(true);
			}
		}
	}
	
	void SaveUpdate(){
		saveText.text = "Escapes: "+GameManager.save;
		coinText.text = "X" + GameManager.coin;
	}
	
	void CheckForGameOver(){
		if(GameManager.gameOver){
			gameOver.SetActive(true);
		}
	}
    
	public void StartGame(){
		startWindow.SetActive(false);
		isStarted = true;
	}	
	
	public void Back(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit(); 
		}
	}
}
