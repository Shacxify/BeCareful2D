using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pedometer : MonoBehaviour {

	public bool start;
	public bool gameOver;
	public float distance = 0f;
	public int speed = 1;

	void Update () {
		GameObject.Find("Canvas/Panel/HSCOREnumber").GetComponent<Text>().text = PlayerPrefs.GetInt("Highscore").ToString();
		if (Input.GetMouseButton(0)) {
			distance += Time.deltaTime;
			start = true;
			GameObject.Find("Canvas/Panel/SCOREnumber").GetComponent<Text>().text = ((int)(distance)).ToString();
			if (distance > PlayerPrefs.GetInt("Highscore")) {
				PlayerPrefs.SetInt("HighScore", (int)(distance));
				Debug.Log("NEW HIGHSCORE" + (int)(distance));
				PlayerPrefs.Save();
			}
		}
	}
}
