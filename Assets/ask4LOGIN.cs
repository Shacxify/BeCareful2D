using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

	public int score;
	public Text userIdText;
	void Awake ()

{
    if (!FB.IsInitialized) {
        // Initialize the Facebook SDK
        FB.Init(InitCallback, OnHideUnity);
    } else {
        // Already initialized, signal an app activation App Event
        FB.ActivateApp();
    }
}

private void InitCallback ()
{
    if (FB.IsInitialized) {
        // Signal an app activation App Event
        FB.ActivateApp();
        // Continue with Facebook SDK
        // ...
    } else {
        Debug.Log("Failed to Initialize the Facebook SDK");
    }
}

public void FBlogin() {
	FB.LogInWithReadPermissions(permissions, AuthCallBack);
}

private void AuthCallBack (ILoginResult result) {
    if (FB.IsLoggedIn) {
			AccessToken token = AccessToken.CurrentAccessToken;
			userIdText.text = token.UserId;
		} else {
			Debug.Log("Canceled Login");
		}
}

public void Share() {
	score = GameObject.Find("Main Camera").GetComponent<mainBrain>().finalDistance;

	FB.ShareLink(contentTitle:"beCAREFUL",
								contentDescription:"");
}

}
