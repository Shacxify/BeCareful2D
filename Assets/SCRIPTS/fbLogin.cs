using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;


public class fbLogin : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		FB.Init(SetInit, OnHideUnity);
	}

	void SetInit() {
		if (FB.IsLoggedIn) {
			Debug.Log("FB is logged in");
		} else {
			Debug.Log("FB is not logged in");
		}

		//DealWithFBMenus(FB.IsLoggedIn);
	}

	void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBlogin() {
		List<string> rpermissions = new List<string> ();
		rpermissions.Add("public_profile");
		List<string> ppermissions = new List<string> ();
		ppermissions.Add("publish_actions");

		FB.LogInWithReadPermissions(rpermissions, AuthCallback);
		FB.LogInWithPublishPermissions(ppermissions, ShareAuthCallback);
	}

	void AuthCallback (IResult result) {
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

	void ShareAuthCallback (IResult result) {
		if (result.Error != null) {
			Debug.Log(result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log("FB is logged in");
				Share();
			} else {
				Debug.Log("FB is not logged in");
			}
		}
	}

	/*void DealWithFBMenus (bool IsLoggedIn) {

		if (IsLoggedIn) {
				DialogLoggedIn.SetActive (true);
				DialogLoggedOut.SetActive (false);

				FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
				FB.API("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
		} else {
			DialogLoggedOut.SetActive (true);
			DialogLoggedIn.SetActive (false);
		}
	}


	void DisplayUsername (IResult result) {
		Text Username = DialogUsername.GetComponent<Text>();

		if (result.Error == null) {
			Username.text = "Hi there, " + result.ResultDictionary["first_name"];
		} else {
			Debug.Log(result.Error);
		}
	}

	void DisplayProfilePic (IGraphResult result) {
		if (result.Texture != null) {
			Image ProfilePic = DialogProfilePic.GetComponent<Image>();

			ProfilePic.sprite = Sprite.Create(result.Texture, new Rect(0,0,128,128), new Vector2());
		}
	}
*/
	public int score = 47;

	public void Share () {
		/*Dictionary<string, string> scoreData = new Dictionary<string, string>() {{"score", score.ToString()}};
		FB.API ("/me/feed", HttpMethod.POST, ShareCallback, scoreData);*/
		FB.ShareLink(
				contentURL: new System.Uri("http://cashjohnson.net/beCAREFUL")
			);
	}

	void ShareCallback (IResult result) {
		if (result.Cancelled) {
			Debug.Log("Share Cancelled");
		} else if (!string.IsNullOrEmpty(result.Error)) {
			Debug.Log("Error on Share!");
		} else if (!string.IsNullOrEmpty(result.RawResult)) {
			Debug.Log("Success on share");
		}
	}

	public void FacebookShare() {
		FBlogin();
		Share();
	}
}
