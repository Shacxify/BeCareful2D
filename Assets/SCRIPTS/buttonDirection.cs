using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using appnext;

public class buttonDirection : MonoBehaviour {

	public bool goToMain;
	public Animator anim;
	public bool shareToggle = false;
	public string placementid;

	public void onClick () {
		if (Application.loadedLevelName == "menu") {
			GameObject.Find("Canvas/title/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
			if (gameObject.name == "madeby") {
				Application.OpenURL("http://www.twitter.com/shacxify");
			} else if (gameObject.name == "play") {
				anim.SetTrigger("ready");
			} else if (gameObject.name == "rate") {
				rate();
			}
		} else if (Application.loadedLevelName == "main") {

			if (gameObject.name == "replay") {
				int roll = Random.Range(0,2);
				if (roll == 0) {
					ShowAd();
				}
				Application.LoadLevel("main");
			} else if (gameObject.name == "goBack") {
				int roll = Random.Range(0,2);
				if (roll == 0) {
					ShowAd();
				}
				Application.LoadLevel("menu");
			} else if (gameObject.name == "share") {
				if (shareToggle == false) {
					shareToggle = true;
					anim.SetBool("share", shareToggle);
				} else if (shareToggle == true) {
					shareToggle = false;
					anim.SetBool("share", shareToggle);
				}

			}
		}
	}

	public void Update() {
		if (Application.loadedLevelName == "menu") {
			anim = GameObject.Find("Canvas").GetComponent<Animator>();
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("out")) {
				if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
					Application.LoadLevel("main");
				}
			}
		} else if (Application.loadedLevelName == "main") {
			anim = GameObject.Find("Canvas").GetComponent<Animator>();
		}
	}

	public void ShowAd()
  {
		if (Advertisement.IsReady()) {
			Advertisement.Show();
		}
  }

	public void rate() {
		#if UNITY_ANDROID
 		Application.OpenURL("market://details?id=com.codemoney.beCAREFUL");
 		#elif UNITY_IPHONE
 		Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
 		#endif
	}
}
