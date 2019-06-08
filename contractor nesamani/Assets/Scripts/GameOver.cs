using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOver : MonoBehaviour
{
	public Text saveText;	
	public Text heighSave;
	public GameObject extraLifeButton;
	public GameObject dialogGo;
	
	private bool lifeTaken = false;
	
	public string placementId = "rewardedVideo";
    
    public bool testMode = false;
	
    #if UNITY_IOS
      private string gameId = "3171731";
    #elif UNITY_ANDROID
       private string gameId = "3171730";
    #elif UNITY_EDITOR_WIN
       private string gameId = "1234567";
    #elif UNITY_STANDALONE_WIN
       private string gameId = "1234567";
    #else
       private string gameId = "1234567";
    #endif
	
	
    // Start is called before the first frame update
    void Start()
    {
        
		Advertisement.Initialize (gameId, testMode);
		
    }

    // Update is called once per frame
    void Update()
    {
        SaveUpdate();
		HighSave();
		LifeTaken();
    }
	
	void SaveUpdate(){
		saveText.text = "Escapes: "+GameManager.save;
	}
	
	void HighSave(){
		int drs = 0;
		int rs = PlayerPrefs.GetInt("RecordSave");
		drs = rs;
		if(GameManager.save > rs){
			PlayerPrefs.SetInt("RecordSave", GameManager.save);
			drs = GameManager.save;
		}
		heighSave.text = "Highest Escapes: "+drs;
	}
	
	public void ExtraLife(){
		GameManager.health = 2;
		gameObject.SetActive(false);
		GameManager.gameOver = false;
		lifeTaken = true;
	}
	
	public void Retry(){
		dialogGo.GetComponent<DialoaugeSay>().PlayAudio();
		GameManager.health = 3;
		GameManager.save = 0;
		GameManager.gameOver = false;
		gameObject.SetActive(false);
		lifeTaken = false;
	}
	
	void LifeTaken(){
		if(lifeTaken){
			extraLifeButton.SetActive(false);
		}else{
			extraLifeButton.SetActive(true);
		}
	}
	
	public void ShowAd()
    {
		
       if (Advertisement.IsReady("rewardedVideo"))
		{
		  ShowOptions options = new ShowOptions();
		  options.resultCallback = HandleShowResult;
		  Advertisement.Show("rewardedVideo", options);
		}
    }
	
	 private void HandleShowResult(ShowResult result){ 
		switch (result){
		  case ShowResult.Finished:
			ExtraLife();
			break;
		  case ShowResult.Skipped:
			Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
			break;
		  case ShowResult.Failed:
			Debug.LogError("Video failed to show");
			break;
		}
	}

}
