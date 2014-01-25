using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Navigation.Waypoints;

public class MoveWaypointsRelativelyToItsParent : MonoBehaviour {
	private WaypointRig wRig;
	private Transform parent;
	private Dictionary<Waypoint, Vector3> waypointDeltaInfo = new Dictionary<Waypoint, Vector3>();

	void Start(){
		wRig = GetComponent<WaypointRig> ();
		parent = transform.parent;
		if (parent != null){
			foreach(Waypoint waypoint in wRig.WaypointSet.Waypoints){
				Vector3 deltaLoc = new Vector3(
					parent.position.x - waypoint.position.x,
					parent.position.y - waypoint.position.y,
					parent.position.z - waypoint.position.z
				);
				waypointDeltaInfo.Add(waypoint, deltaLoc);
			}
		}
	}

	void Update(){
		if (parent != null) {
			foreach(KeyValuePair<Waypoint, Vector3> entry in waypointDeltaInfo){
				entry.Key.position = new Vector3(
					parent.position.x - entry.Value.x,
					parent.position.y - entry.Value.y,
					parent.position.z - entry.Value.z
				);
			}
		}
	}
}
