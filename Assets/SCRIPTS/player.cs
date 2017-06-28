using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	public float moveSpeed;
	public Rigidbody2D rb;
	Ray ray;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && Input.mousePosition == gameObject.transform.position) {
			Vector3 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			curPos.z = 0;
			gameObject.transform.position = curPos;
		}
	}

	public void OnCollisionEnter2D(Collision2D col) {
			Debug.Log("TOuCHING!");
			GameObject.Find("Main Camera").GetComponent<pedometer>().gameOver = true;
	}

	void FixedUpdate () {
		rb.velocity = new Vector2(0,0);
    rb.angularVelocity = 0f;
		rb.AddForce(new Vector2(moveSpeed,moveSpeed));
	}
}
