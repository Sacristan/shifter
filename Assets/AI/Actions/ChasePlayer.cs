using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class ChasePlayer : RAINAction
{
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
		moveToPos = ai.WorkingMemory.GetItem ("target").GetValue<GameObject> ().transform.position;
		
		ai.Motor.moveTarget.VectorTarget = moveToPos ;
		ai.Motor.Allow3DRotation = false;
		
		if (!ai.Motor.Move ()) {
			
		} else {
			
		}
		
		return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}