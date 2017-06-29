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

	void Update () {
		mouseOn = GameObject.Find("pixelcircle").GetComponent<player>().mouseOver;
		//GameObject.Find("Canvas/Panel/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
		if (Input.GetMouseButton(0) && gameOver != true && mouseOn) {
			distance += Time.deltaTime;
			start = true;
			GameObject.Find("Canvas/Panel/SCOREnumber").GetComponent<Text>().text = ((int)(distance)).ToString();
		} else if (Input.GetMouseButtonUp(0) && mouseOn) {
			gameOver = true;
		}
	}
}
