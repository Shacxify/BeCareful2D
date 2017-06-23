using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleMovement : MonoBehaviour {

	public float speed;
	public int lvl;
	public GameObject player;
	public pedometer pedo;
	public GameObject spike, newSpike;


	// Update is called once per frame
	void Start () {
		player = GameObject.Find("Canvas/pixelcircle");
		pedo = player.GetComponent<pedometer>();
		lvl = 0;
		speed = GameObject.Find("Main Camera").GetComponent<mainBrain>().speed;
	}

	void Update () {
		if (Input.GetKeyDown("j")) {
			createSpike();
		}
	}

	public int roll () {
		//0=LEFT;1=RIGHT;
		return Random.Range(0, 2);
	}

	void createSpike () {
		int decide = roll();
		if (decide >= 1) {
			newSpike = Instantiate(spike, new Vector3(-1.4f, 6.87f, 1), Quaternion.Euler(0, 0, 0));
			newSpike.transform.localScale = new Vector2(8,8);
		} else if (decide < 1) {
			newSpike = Instantiate(spike, new Vector3(1.4f, 6.87f, 1), Quaternion.Euler(0, 0, 0));
			newSpike.transform.localScale = new Vector2(-8,8);
		}
	}


}
