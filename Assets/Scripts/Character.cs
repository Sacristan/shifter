﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {


	public float speed = 10;
	public float jumpStrength = 10;
	private float correctedSpeed;
	private Vector3 pos = Vector3.zero;
	private Vector2 move = Vector2.zero;
	private Rigidbody2D rig2D;
	private int jumpCount = 0;
	private float lastFrameY;
	// Use this for initialization
	void Awake () {
		rig2D = this.GetComponent<Rigidbody2D> ();
		correctedSpeed = speed * 100;
		lastFrameY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {



		pos = transform.position;
		//pos.x += Input.GetAxis ("Horizontal")*Time.deltaTime * speed;

		pos.z = 0;
		transform.position = pos;
		move = new Vector2 (Input.GetAxis("Horizontal")*Time.deltaTime*correctedSpeed,(Jump() ? jumpStrength:0));
		rig2D.AddForce(move);

	}

	private bool Jump() {
		if (Input.GetButtonDown ("Jump") && jumpCount < 2) {
			jumpCount++;
			return true;
		}
		else{
			return false;
		}
	}

	void OnCollisionStay(Collision collision) {
		Debug.Log (jumpCount);
		jumpCount = 0;
	}
}
