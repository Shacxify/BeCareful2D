using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "123456789000";
	private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";
	private int roll;
	private string sent;
	public int finalScore;

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
				//ShareToFacebook("");
		} else if (gameObject.name == "twitterlogo") {

				ShareToTwitter("I scored " + finalScore + " on beCAREFUL. " + sent);
		}

	}


	void ShareToFacebook (string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter)
	{
		Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
		"&link=" + WWW.EscapeURL(linkParameter) +
		"&name=" + WWW.EscapeURL(nameParameter) +
		"&caption=" + WWW.EscapeURL(captionParameter) +
		"&description=" + WWW.EscapeURL(descriptionParameter) +
		"&picture=" + WWW.EscapeURL(pictureParameter) +
		"&redirect_uri=" + WWW.EscapeURL(redirectParameter));
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en";

	void ShareToTwitter (string textToDisplay)
	{
		Application.OpenURL(TWITTER_ADDRESS +
		"?text=" + WWW.EscapeURL(textToDisplay) +
		"&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}
}
