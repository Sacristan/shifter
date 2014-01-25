using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public Transform Target;
	private Vector3 pos = Vector3.zero;
	public float parallaxAmount = 2F;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pos = transform.position;
		pos.x = Target.position.x/parallaxAmount;
		pos.y = Target.position.y/parallaxAmount;
		transform.position = pos;
	}
}
