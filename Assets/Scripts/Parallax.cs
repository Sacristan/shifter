using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public float height;

	public void Start() {

		Vector3 scale = transform.localScale;
		scale.x = transform.parent.GetComponent<Chunk> ().width;
		transform.localScale = scale;
		Vector3 tempPos = transform.position;
		tempPos.y = height;
		transform.position = tempPos;

	}
}
