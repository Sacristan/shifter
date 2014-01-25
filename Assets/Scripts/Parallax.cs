using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float height;

	public void Start() {

		Vector3 tempPos = transform.position;
		tempPos.y = height;
		transform.position = tempPos;

	}
}
