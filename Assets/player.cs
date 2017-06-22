using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	public float moveSpeed;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Vector3 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			curPos.z = 0;
			gameObject.transform.position = curPos;
		}
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "barrier"){
			Debug.Log("TOuCHING!");
		}
	}

	void FixedUpdate () {
		rb.velocity = new Vector2(0,0);
    rb.angularVelocity = 0f;
		rb.AddForce(new Vector2(moveSpeed,moveSpeed));
	}
}
