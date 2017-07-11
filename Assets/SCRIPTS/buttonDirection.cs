using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class buttonDirection : MonoBehaviour {

	public bool goToMain;
	public Animator anim;
	public bool shareToggle = false;

	public void onClick () {
		if (Application.loadedLevelName == "menu") {
			anim.SetTrigger("ready");
			GameObject.Find("Canvas/title/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
			if (gameObject.name == "madeby") {
				Application.OpenURL("http://www.twitter.com/shacxify");
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
    if (Advertisement.IsReady())
    {
      Advertisement.Show();
    }
  }
}
