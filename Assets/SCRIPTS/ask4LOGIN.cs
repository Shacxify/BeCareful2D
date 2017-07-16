using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "118943272041914";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	private int roll;
	private string sent;
	public int finalScore;

	void Awake ()
	{
		if (FB.IsInitialized) {
        FB.ActivateApp();
    } else {
        //Handle FB.Init
        FB.Init( () => {
            FB.ActivateApp();
        });
    }
		}

	public void Update () {
		finalScore = (int)GameObject.Find("Main Camera").GetComponent<pedometer>().distance;
	}

	public void onClick () {
		roll = Random.Range(1,5);
		switch(roll) {
			case 1:
				sent = "I doubt you can beat me!";
				break;
			case 2:
				sent = "Try to beat me!";
				break;
			case 3:
				sent = "You can't beat me!";
				break;
			case 4:
				sent = "Think you can beat that?";
				break;
		}

		if (gameObject.name == "fb") {
				//ShareToFacebook("BeCAREFUL", "I scored " + finalScore + " on beCAREFUL. " + sent, "I scored " + finalScore + " on beCAREFUL. " + sent, "https://flic.kr/p/Wqdb4u", "https://www.cashjohnson.net");
				Share();
		} else if (gameObject.name == "twitterlogo") {

				ShareToTwitter("I scored " + finalScore + " on beCAREFUL. " + sent);
		}

	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";

	void ShareToTwitter (string textToDisplay)
	{
		Application.OpenURL(TWITTER_ADDRESS +
		"?text=" + WWW.EscapeURL(textToDisplay) +
		"&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}

	public void LogIn() {
		FB.LogInWithPublishPermissions(callback:OnLogIn);
	}

	private void OnLogIn(ILoginResult result) {
		if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			Debug.Log(token.UserId);
		} else {
			Debug.Log("Cancelled Login");
		}
	}

	public void Share () {
		LogIn();
		FB.ShareLink(
			contentURL: new System.Uri("https://www.facebook.com/feed"),
			contentTitle: "beCAREFUL",
			contentDescription: "I thought up a witty tagline about larches",
			//picture: new System.Uri("http://www.cashjohnson.net/ico.png")
			callback: OnShare
		);
	}

	private void OnShare(IShareResult result) {
		if (result.Cancelled || !string.IsNullOrEmpty(result.Error)) {
			Debug.Log("ShareLink error: " + result.Error);
		} else if (!string.IsNullOrEmpty(result.PostId)) {
			Debug.Log(result.PostId);
		} else {
			Debug.Log("Share Succeed");
		}
	}
}
