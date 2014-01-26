using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudScript : MonoBehaviour {

	public GameObject cloud;
	public float far; // sorry a bit too tired to find a more suitable name
	private List<GameObject> clouds = new List<GameObject>();

	public int number = 20;
	public Vector3 spread = Vector3.one;
	public float speed = 10;

	private Vector3 tempVec;
	void Start() {
		for (int i = 0; i < number; i++ ){
			Vector3 initialPos = Vector3.Scale(Random.insideUnitSphere,spread) + (Vector3.right*far*i);
			GameObject tempCloud = Instantiate(cloud,initialPos,Quaternion.identity) as GameObject;
			tempCloud.transform.parent = this.transform;
			tempVec = Vector3.one;
			tempVec.x *= Random.Range(1F,3F);
			tempVec.y *= Random.Range(0.5F,2F);
			tempCloud.transform.localScale = tempVec;
			clouds.Add(tempCloud);
		}
	}

}	