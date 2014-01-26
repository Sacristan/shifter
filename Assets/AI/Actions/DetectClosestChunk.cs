using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Navigation.Waypoints;

[RAINAction]
public class DetectClosestChunk : RAINAction
{
    public DetectClosestChunk()
    {
        actionName = "DetectClosestChunk";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(AI ai)
    {
		RaycastHit hit;

		if (Physics.Raycast (ai.Body.transform.position, -Vector3.up, out hit, 5.0f)) {
			GameObject go = hit.collider.gameObject;
			if(go == null) return ActionResult.FAILURE;

			WaypointRig wRig = go.GetComponentInChildren<WaypointRig>();

			if(wRig != null){
				ai.WorkingMemory.SetItem("waypointPathToUse", wRig.gameObject);
				return ActionResult.SUCCESS;
			}
			else return ActionResult.FAILURE;
		}
		return ActionResult.FAILURE;
	}

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}