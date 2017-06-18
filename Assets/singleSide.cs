using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleSide : MonoBehaviour {

	float speed;
	// Use this for initialization
	void Start () {
		speed = GameObject.Find("Main Camera").GetComponent<mainBrain>().speed * -1;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
