using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceSimulate : MonoBehaviour {

	public Rigidbody2D rb;
	public float moveSpeed;

	void Start () {
		moveSpeed = Random.Range(0.001f,0.002f);
	}

	void FixedUpdate () {
		rb.velocity = new Vector2(0,0);
    rb.angularVelocity = 0f;
		rb.AddForce(new Vector2(moveSpeed,moveSpeed));
	}
}
