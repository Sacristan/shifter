using UnityEngine;
using System.Collections;

public class cloud : MonoBehaviour {

	private Vector3 spread = Vector3.one;
	private float speed = 10;
	private float far = 30;

	// Use this for initialization
	void Start () {
		speed = transform.parent.GetComponent<CloudScript>().speed;
		spread = transform.parent.GetComponent<CloudScript> ().spread;
		far = transform.parent.GetComponent<CloudScript> ().far;
	}

	Vector3 tempPos = Vector3.zero;
	// Update is called once per frame
	void Update () {
		tempPos = transform.localPosition;
		tempPos.x -= speed*Time.deltaTime;
		transform.localPosition = tempPos;
	}

	void OnBecameInvisible() {
		tempPos = Vector3.Scale(Random.insideUnitSphere,spread) + (Vector3.right*far);
		tempPos.x -= speed*Time.deltaTime;
		transform.localPosition = tempPos;
		transform.localScale = Vector3.one;
	}

}
