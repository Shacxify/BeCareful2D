using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceSimulate : MonoBehaviour {

	public Rigidbody2D rb;
	public float moveSpeedX, moveSpeedY;
	public float timeCheck = 2.5f, setTime;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		moveSpeedX = Random.Range(-0.002f,0.002f);
		moveSpeedY = Random.Range(-0.002f,0.002f);
		rb.AddForce(new Vector2(moveSpeedX,moveSpeedY));
		setTime = timeCheck;
	}

	void Update () {
			timeCheck -= Time.deltaTime;
     if ( timeCheck < 0 ) {
			moveSpeedX = Random.Range(-0.002f,0.002f);
			moveSpeedY = Random.Range(-0.002f,0.002f);
			rb.AddForce(new Vector2(moveSpeedX,moveSpeedY));
			timeCheck = setTime;
   	}
	}
}
