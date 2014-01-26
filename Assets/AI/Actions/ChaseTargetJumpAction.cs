using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class ChaseTargetJumpAction : RAINAction
{
	Vector3 minMaxJumpDist = new Vector3(0.0f, 1.0f);
	float diffXDist = 1.0f;
	float xOffset = 1f;

    public ChaseTargetJumpAction()
    {
        actionName = "ChaseTargetJumpAction";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {
		GameObject target = ai.WorkingMemory.GetItem ("target").GetValue<GameObject> ();
		GameObject self = ai.Body;

		ai.Motor.Allow3DRotation = false;

		Vector3 diffVec = target.transform.position - self.transform.position;
		float xForm;
		float yForm;

		xForm = target.transform.position.x - (diffVec.x - (diffXDist * Mathf.Sign(diffVec.x))) - (xOffset * Mathf.Sign(diffVec.x));
		yForm = target.transform.position.y + target.transform.lossyScale.y * 0.5f;

		if(diffVec.y <= minMaxJumpDist.y && diffVec.y >= minMaxJumpDist.x){
			Vector3 jumpToLoc = new Vector3 (
				xForm,
				yForm,
				self.transform.position.z
			);

//			jumpToLoc = target.transform.position;
			ai.WorkingMemory.SetItem("jumpTarget", jumpToLoc);
			Debug.DrawLine(self.transform.position, jumpToLoc, Color.blue);


	        return ActionResult.SUCCESS;
		}
		else{
			Debug.Log(diffVec);
			return ActionResult.SUCCESS;
		}
	
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}