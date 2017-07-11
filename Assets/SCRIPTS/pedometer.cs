using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pedometer : MonoBehaviour {

	public bool start;
	public bool gameOver;
	public float distance = 0f;
	public int speed = 1;
	public bool mouseOn;
	public Animator anim;

	void Awake () {
		GameObject.Find("Canvas/Panel/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
		anim = GameObject.Find("Canvas").GetComponent<Animator>();
	}

	void Update () {
		mouseOn = GameObject.Find("pixelcircle").GetComponent<player>().mouseOver;
		//GameObject.Find("Canvas/Panel/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
		if (Input.GetMouseButton(0) && gameOver != true && mouseOn) {
			distance += Time.deltaTime;
			start = true;
			GameObject.Find("Canvas/Panel/SCOREnumber").GetComponent<Text>().text = ((int)(distance)).ToString();
		} else if (Input.GetMouseButtonUp(0) && mouseOn) {
			int finalDist = (int)distance;
			if (finalDist > PlayerPrefs.GetInt("highscore")){
				PlayerPrefs.SetInt("highscore", finalDist);
				anim.SetTrigger("highscore");
				GameObject.Find("Canvas/Panel/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("highscore").ToString();
			}
			gameOver = true;
		}
	}
}
