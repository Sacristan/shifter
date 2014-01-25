using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {

	public Transform Target;
	private Vector3 pos = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		pos = transform.position;
		pos.x = Target.position.x;
		pos.y = Target.position.y;
		transform.position = pos;
	}
}
