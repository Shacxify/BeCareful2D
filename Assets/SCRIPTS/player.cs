using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	public float moveSpeed;
	public Rigidbody2D rb;
	Ray ray;
	RaycastHit hit;
	public bool mouseOver;
	public AudioSource deathSound;
	public AudioClip deathsound;

	// Use this for initialization
	void Start () {
		mouseOver = false;
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && mouseOver) {
			Vector3 curPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			curPos.z = 0;
			gameObject.transform.position = curPos;

		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if(Input.GetMouseButton(0)) {
			if(Physics.Raycast(ray, out hit)) {
				print(hit.collider.name);
			}
		}
	}

	public void OnCollisionEnter2D(Collision2D col) {
		Debug.Log("TOuCHING!");
		GameObject.Find("Main Camera").GetComponent<pedometer>().gameOver = true;
		deathSound.PlayOneShot(deathsound);
		Destroy(gameObject.GetComponent<Collider2D>());
	}

	public void OnMouseOver () {
		mouseOver = true;
	}

	public void OnMouseUp () {
		if (gameObject.GetComponent<Collider2D>() != null) {
			deathSound.PlayOneShot(deathsound);
			Destroy(gameObject.GetComponent<Collider2D>());
		}
	}

	void FixedUpdate () {
		rb.velocity = new Vector2(0,0);
		rb.angularVelocity = 0f;
		rb.AddForce(new Vector2(moveSpeed,moveSpeed));
	}
}
