using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation.Waypoints;

[RAINAction]
public class ChasePlayer : RAINAction
{
	float jumpTime = 2.0f;
	Vector3 jumpToLoc;

    public ChasePlayer()
    {
        actionName = "ChasePlayer";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {
		Vector3 moveToPos;
		GameObject target = ai.WorkingMemory.GetItem ("target").GetValue<GameObject> ();
		moveToPos = target.transform.position;
		
		ai.Motor.moveTarget.VectorTarget = moveToPos ;
		ai.Motor.Allow3DRotation = false;
		float yDiff = target.transform.position.y - ai.Kinematic.Position.y;

		if(yDiff >= 0.5f && yDiff <= 1.0f){
			IsAtANavPoint(ai);
			JumSeq(ai, target);
		}
		if (ai.WorkingMemory.ItemExists ("jumpTarget")) return ActionResult.RUNNING;

		if (!ai.Motor.Move ()) {
			return ActionResult.RUNNING;
		}
		else return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }

	private bool IsAtANavPoint(AI ai){
		return false;
//		RaycastHit hit;
//		if (Physics.Raycast (ai.Body.transform.position, -Vector3.up, out hit, 5.0f)) {
//			GameObject go = hit.collider.gameObject;
//			if(go == null) return false;
//			
//			WaypointRig[] wRigs = go.GetComponentsInChildren<WaypointRig>();
//
//			foreach(WaypointRig wRig in wRigs){
//				ai.Navigator.IsAt(mlt);
//			}
//			return false;
//		}
	}

	private void  JumSeq(AI ai, GameObject target){

//		RaycastHit hit;
//		
//		Physics.Raycast (ai.Body.transform.position, -Vector3.up, out hit, 1.0f);
//		
//		if(!ai.WorkingMemory.ItemExists("jumpTarget")){
//			bool isAgentOnFloor = Physics.Raycast (ai.Body.transform.position, -Vector3.up, out hit, 1.0f);
//			bool isTargetOnFloor = Physics.Raycast(target.transform.position, -Vector3.up, out hit, 1.0f);
//			if( isAgentOnFloor && isTargetOnFloor ){
//				jumpToLoc = new Vector3(
//					target.transform.position.x,
//					target.transform.position.y + target.transform.lossyScale.y * 0.5f,
//					target.transform.position.z
//				);
//				ai.WorkingMemory.SetItem("jumpTarget", jumpToLoc);
//				ai.Body.SendMessage("Jump", ai);
//			}
//		}
	}
}