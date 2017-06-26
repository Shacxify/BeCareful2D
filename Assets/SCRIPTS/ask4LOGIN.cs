using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init();
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	/*private void InitCallback ()
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
	}*/




private void ShareCallback (IShareResult result) {
    if (result.Cancelled || !string.IsNullOrEmpty(result.Error)) {
        Debug.Log("ShareLink Error: "+result.Error);
    } else if (!string.IsNullOrEmpty(result.PostId)) {
        // Print post identifier of the shared content
        Debug.Log(result.PostId);
    } else {
        // Share succeeded without postID
        Debug.Log("ShareLink success!");
    }
}




		private void AuthCallback (ILoginResult result) {

			if (FB.IsLoggedIn) {
				// AccessToken class will have session details
				AccessToken aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
				// Print current access token's User ID


				if (aToken != null) {
				Debug.Log(aToken.UserId);
				// Print current access token's granted permissions
			}
			} else {
				Debug.Log("User cancelled login");
			}
		}

		public void onClick () {
			//var perms = new List<string>(){"public_profile", "email", "user_friends"};
			FB.LogInWithReadPermissions(callback:AuthCallback);
		}


	}
