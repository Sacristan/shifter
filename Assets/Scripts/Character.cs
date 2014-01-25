﻿using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {


	public float speed = 10;
	public float jumpStrength = 10;
	private float correctedSpeed;
	private Vector3 pos = Vector3.zero;
	private Vector2 move = Vector2.zero;
	private Rigidbody2D rig2D;

	// Use this for initialization
	void Awake () {
		rig2D = this.GetComponent<Rigidbody2D> ();
		correctedSpeed = speed * 100;
	}
	
	// Update is called once per frame
	void Update () {

		pos = transform.position;
		//pos.x += Input.GetAxis ("Horizontal")*Time.deltaTime * speed;

		pos.z = 0;
		transform.position = pos;
		move = new Vector2 (Input.GetAxis("Horizontal")*Time.deltaTime*correctedSpeed,(Input.GetButtonDown("Jump") ? jumpStrength:0));
		rig2D.AddForce(move);

	}
}
