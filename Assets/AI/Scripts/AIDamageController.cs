using UnityEngine;
using System.Collections;
using RAIN.Core;

public class AIDamageController : MonoBehaviour {
	public float hitPoints = 100.0f;
	private AIRig aiRig = null;

	void Awake(){
		aiRig = gameObject.GetComponentInChildren<AIRig> ();
		aiRig.AI.WorkingMemory.SetItem("health", hitPoints);
	}

	void Update(){
		aiRig.AI.WorkingMemory.SetItem("health", hitPoints);
	}
}
