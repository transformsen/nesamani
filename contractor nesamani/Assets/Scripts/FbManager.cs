using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class FbManager : MonoBehaviour
{
	public Text userIdText;	
	public GameObject gameOver;
	
    // Start is called before the first frame update
    void Awake()
    {
        if(!FB.IsInitialized){
			FB.Init();
		}else{
			FB.ActivateApp();
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void LogIn(){
		FB.LogInWithReadPermissions(callback: OnLogIn);
	}
	
	void OnLogIn(ILoginResult result){
		Debug.Log("OnLogIn");
		if(FB.IsLoggedIn){
			Share();
		}else{
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = token.UserId;
		}
	}
	
	public void Share(){
		Debug.Log("Share");
		if(!FB.IsLoggedIn){
			LogIn();
		}else{
			Debug.Log("Share else");
			FB.ShareLink(contentTitle:"Contractor Nesamani",
			contentURL: new System.Uri("https://kuttyminimi.blogspot.com/2019/06/contractor-nesamani.html"),
			contentDescription: "#play_for_nesamani Today's Escapes : "+GameManager.save,
			callback: OnShare);
		}		
	}
	
	void OnShare(IShareResult result){
		if (result.Cancelled || !string.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink Error: "+result.Error);
		} else if (!string.IsNullOrEmpty(result.PostId)) {
			// Print post identifier of the shared content
			Debug.Log(result.PostId);
		} else {
		   Debug.Log("ShareLink Sucess: ");
		}
	}
}
