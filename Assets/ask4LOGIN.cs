using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

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

private void OnHideUnity (bool isGameShown)
{
    if (!isGameShown) {
        // Pause the game - we will need to hide
        Time.timeScale = 0;
    } else {
        // Resume the game - we're getting focus again
        Time.timeScale = 1;
    }
}

public void FBlogin() {
	List<string> permissions = new List<string> {};
	permissions.Add ("public_profile");

	FB.LogInWithReadPermissions(permissions, AuthCallBack);
}

private void AuthCallBack (ILoginResult result) {
    if (result.Error != null) {
			Debug.Log(result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log("FB is logged in");
			} else {
				Debug.Log("FB is not logged in");
			}
		}
}

}
