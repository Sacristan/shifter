using UnityEngine;
using System.Collections;
using RAIN.Core;

public class AIController : MonoBehaviour {
	public float hitPoints = 100.0f;
	private AIRig aiRig = null;
	private float jumpTimePerMeter = 1.0f;

	void Awake(){
		aiRig = gameObject.GetComponentInChildren<AIRig> ();
		aiRig.AI.WorkingMemory.SetItem("health", hitPoints);
	}

	void Update(){
		aiRig.AI.WorkingMemory.SetItem("health", hitPoints);
	}

	void ApplyDamage(float dmg){
		hitPoints = Mathf.Clamp (hitPoints - dmg, 0.0f, hitPoints);
	}


	void Jump(RAIN.Core.AI param){
		StartCoroutine (JumpRoutine (param));
	}
	IEnumerator JumpRoutine(RAIN.Core.AI thisAi){
		Vector3 jumpLoc = thisAi.WorkingMemory.GetItem("jumpTarget").GetValue<Vector3>();
		float jumpTime = Vector3.Distance(thisAi.Kinematic.Position, jumpLoc) * jumpTimePerMeter;
		iTween.MoveTo(thisAi.Body,jumpLoc, jumpTime);
		yield return new WaitForSeconds (jumpTime);
		thisAi.WorkingMemory.RemoveItem ("jumpTarget");
	}
}
