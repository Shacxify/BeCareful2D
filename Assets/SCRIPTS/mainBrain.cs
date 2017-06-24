using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBrain : MonoBehaviour {

	public GameObject un, dos;
	public float level;
	public float speed, baseSpeed;
	public GameObject player;
	public pedometer pedo;
	public GameObject spike, newSpike;
	public float freq;
	public float timeTillSpawn, sinceLast;
	public bool start, gameOver;
	public Animator pixelcircleAnim, canvasAnim;
	public float spikeTime;

	// Update is called once per frame
	void Start () {
		timeTillSpawn = 1;
		baseSpeed = speed;
		player = GameObject.Find("Canvas/pixelcircle");
		pedo = GameObject.Find("Main Camera").GetComponent<pedometer>();
		level = 0;
		pixelcircleAnim = player.GetComponent<Animator>();
		canvasAnim = GameObject.Find("Canvas").GetComponent<Animator>();
	}

	void Update () {
		start = GameObject.Find("Main Camera").GetComponent<pedometer>().start;
		gameOver = GameObject.Find("Main Camera").GetComponent<pedometer>().gameOver;


		if (sinceLast <= 0) {
			createSpike(3);
			//spikeTime = 5;
			sinceLast = 5;
		}
		sinceLast -= Time.deltaTime * (speed * 15);

		if (start == true) {
			pixelcircleAnim.SetTrigger("start");
			if ((int)pedo.distance % freq == 0) {
				speed += .00010f;
			}
		}

		if (gameOver == true) {
			pixelcircleAnim.SetTrigger("gameover");
			canvasAnim.SetTrigger("gameover");
		}
		//Create random spike
		if (Input.GetKeyDown("j")) {
			createSpike(3);
		}

		//Move the LEFT and RIGHT barriers down
		if (gameOver != true) {
			if (un.transform.position.y <= -13.38) {
				un.transform.Translate(new Vector2(0, 33.51f));
			}
			if (dos.transform.position.y <= -13.38) {
				dos.transform.Translate(new Vector2(0, 33.51f));
			}
			un.transform.Translate(new Vector2(0, speed * -1));
			dos.transform.Translate(new Vector2(0, speed * -1));
		}
	}



	public int roll () {
		//0=LEFT;1=RIGHT;
		return Random.Range(0, 2);
	}



	void createSpike (int amount) {
		float posY = 6.87f;
		for (int i = amount; i > 0; i--) {
			int decide = roll();
			Debug.Log("LOGGED");
			if (decide >= 1) {
				newSpike = Instantiate(spike, new Vector3(-1.4f, posY, 1), Quaternion.Euler(0, 0, 0));
				newSpike.transform.localScale = new Vector2(8,8);
			} else if (decide < 1) {
				newSpike = Instantiate(spike, new Vector3(1.4f, posY, 1), Quaternion.Euler(0, 0, 0));
				newSpike.transform.localScale = new Vector2(-8,8);
			}
		posY += 2.34f;
		}
	}
}
