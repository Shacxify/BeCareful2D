﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDirection : MonoBehaviour {

	public bool goToMain;
	public Animator anim;

	public void onClick () {
		if (Application.loadedLevelName == "menu") {
			anim.SetTrigger("ready");
		}
	}

	public void Update() {
		if (Application.loadedLevelName == "menu") {
			anim = GameObject.Find("Canvas").GetComponent<Animator>();
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("out")) {
				if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) {
					Application.LoadLevel("main");
				}
			}
		}
	}
}
