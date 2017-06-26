using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class ask4LOGIN : MonoBehaviour {

	private const string FACEBOOK_APP_ID = "123456789000";
private const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

public void onClick() {
	ShareToFacebook();
}

void ShareToFacebook (/*string linkParameter, string nameParameter, string captionParameter, string descriptionParameter, string pictureParameter, string redirectParameter*/)
{
Application.OpenURL (FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
"&link=" + WWW.EscapeURL("https//:www.google.com") +
"&name=" + WWW.EscapeURL("beCAREFUL") +
"&caption=" + WWW.EscapeURL("HIGHSCORE!") +
"&description=" + WWW.EscapeURL("memeLIFE") +
"&redirect_uri=" + WWW.EscapeURL("http://www.facebook.com/"));
}

}
