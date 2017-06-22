using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBrain : MonoBehaviour {

	public GameObject un, dos;
	public float speed;

	// Update is called once per frame
	void Update () {
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
