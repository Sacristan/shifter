using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {


	public float speed = 10;
	public float jumpStrength = 10;
	private float correctedSpeed;
	private Vector3 pos = Vector3.zero;
	private Vector2 move = Vector2.zero;
	private Rigidbody rig2D;
	private int jumpCount = 0;
	private float lastFrameY;
	// Use this for initialization
	void Awake () {
		rig2D = this.GetComponent<Rigidbody> ();
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
		Vector3 velocity = rig2D.velocity;
		velocity.x = Mathf.Clamp (rig2D.velocity.x,-10F, 10F);
		rig2D.velocity = velocity;
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
}
