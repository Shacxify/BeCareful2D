using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

	public float speed;

	// Update is called once per frame
	void Update () {
		speed = GameObject.Find("Main Camera").GetComponent<mainBrain>().speed;
		if (gameObject.transform.position.y <= -6.10f) {
				Destroy(gameObject);
		}
		gameObject.transform.Translate(new Vector2(0, (speed * -1)+(speed * .25f)));
	}
}
