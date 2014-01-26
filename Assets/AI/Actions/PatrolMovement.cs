using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class PatrolMovement : RAINAction
{
	Vector3 moveToPos;

    public PatrolMovement()
    {
        actionName = "PatrolMovement";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {

		if (!ai.WorkingMemory.ItemExists ("patrolTargetVec")) {
			RAIN.Motion.MoveLookTarget mlt = ai.WorkingMemory.GetItem ("patrolTarget").GetValue<RAIN.Motion.MoveLookTarget> ();
			ai.WorkingMemory.SetItem("patrolTargetVec", mlt.Position);
		}
		moveToPos = ai.WorkingMemory.GetItem ("patrolTargetVec").GetValue<Vector3> ();
//		Debug.Log (moveToPos);
		
		ai.Motor.moveTarget.VectorTarget = moveToPos ;
		ai.Motor.Allow3DRotation = false;
		
		if (!ai.Motor.Move ()) {
			return ActionResult.RUNNING;
		} else {
			ai.WorkingMemory.RemoveItem ("patrolTargetVec");
			return ActionResult.SUCCESS;
		}
		

    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}