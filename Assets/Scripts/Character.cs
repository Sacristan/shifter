﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {


	public float speed = 10;
	public float jumpStrength = 10;
	private float correctedSpeed;
	private Vector3 pos = Vector3.zero;
	private Vector2 move = Vector2.zero;
	private Rigidbody rig2D;
	private int jumpCount = 0;


	private Ray leftRay;
	private RaycastHit hitLeft;
	private Ray rightRay;
	private RaycastHit hitRight;


	public List<GameObject> vies = new List<GameObject>();

	void Awake () {
		rig2D = this.GetComponent<Rigidbody> ();
		correctedSpeed = speed * 100;


		hitLeft = new RaycastHit();

		hitRight = new RaycastHit();
		foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Life")) {
			vies.Add(heart);
		}
	}

	void Update () {

		move = new Vector2 (Input.GetAxis("Horizontal")*Time.deltaTime*correctedSpeed,(Jump() ? jumpStrength:0));
		//move.x *= detectCloseWalls()*10F;    
		rig2D.AddForce(move);
		Vector3 velocity = rig2D.velocity;
		velocity.x = Mathf.Clamp (rig2D.velocity.x,-10F, 10F);
		rig2D.velocity = velocity;

		if (vies.Count == 0 || transform.position.y < -30) {

			Application.LoadLevel("Menu");

		}
	}

	private bool Jump() {
		if (Input.GetButtonDown ("Jump") && jumpCount < 1) {
			jumpCount++;
			return true;
		}
		else{
			return false;
		}
	}

	void OnCollisionStay(Collision collision) {
		jumpCount = 0;
	}
	void OnCollisionEnter(Collision collision) {
		jumpCount = 0;
	}

	private bool detectCloseWalls() {
		bool left = false;
		bool right = false;
		Vector3 rayStart = transform.position + Vector3.up;
		leftRay = new Ray (rayStart, Vector3.left);
		Debug.DrawRay (rayStart, Vector3.left);
		rightRay = new Ray (rayStart, Vector3.right);
		Debug.DrawRay (rayStart, Vector3.right);

		if (collider.Raycast (leftRay, out hitLeft, 12)) {
			if(Mathf.Abs(Vector3.Distance(this.transform.position,hitLeft.point)) < 0.5F){
				left = true;
			}
		}
		if (collider.Raycast (rightRay, out hitRight, 12)) {
			if(Mathf.Abs(Vector3.Distance(this.transform.position,hitRight.point)) < 0.5F){
				right = true;
			}
		}
		return left || right;

	}

	public void OnCollisionEnter(Collider collider){

		if (collider.gameObject.CompareTag("Enemy")) {

				GameObject.FindGameObjectWithTag("Life").GetComponent<MeshRenderer>().enabled = false;

		}
	}
	
}
