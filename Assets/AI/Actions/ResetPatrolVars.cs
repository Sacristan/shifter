using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;

[RAINAction]
public class ResetPatrolVars : RAINAction
{
    public ResetPatrolVars()
    {
        actionName = "ResetPatrolVars";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {
		ai.WorkingMemory.RemoveItem ("patrolTarget");
		ai.WorkingMemory.RemoveItem ("patrolTargetVec");
		ai.WorkingMemory.RemoveItem ("waypointPathToUse");
        return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}