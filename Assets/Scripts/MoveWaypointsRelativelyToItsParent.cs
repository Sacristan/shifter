using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Navigation.Waypoints;

public class MoveWaypointsRelativelyToItsParent : MonoBehaviour {
	private WaypointRig wRig;
	private Dictionary<Waypoint, Vector3> waypointDeltaInfo = new Dictionary<Waypoint, Vector3>();

	void Awake(){
		wRig = GetComponent<WaypointRig> ();

		foreach(Waypoint waypoint in wRig.WaypointSet.Waypoints){
	
			Vector3 deltaLoc = new Vector3(
				transform.position.x - (waypoint.position.x ) - transform.position.x,
				transform.position.y - (waypoint.position.y ) - transform.position.y,
				transform.position.z - (waypoint.position.z ) - transform.position.z
			);
			waypointDeltaInfo.Add(waypoint, deltaLoc);
		}

		wRig.gameObject.name = wRig.gameObject.name + wRig.gameObject.GetInstanceID ().ToString ();
	}

	void Update(){
		ApplyPos ();
	}

	void ApplyPos(){
		foreach(KeyValuePair<Waypoint, Vector3> entry in waypointDeltaInfo){
			entry.Key.position = new Vector3(
				transform.position.x - entry.Value.x,
				transform.position.y - entry.Value.y,
				transform.position.z - entry.Value.z
			);
		}
		Destroy (this);
	}
}
