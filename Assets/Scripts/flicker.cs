using UnityEngine;
using System.Collections;

public class flicker : MonoBehaviour {

	private Light light;
	// Use this for initialization
	void Start () {
		light = this.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		light.intensity = Random.Range (1.0F, 2.0F);
	}
}
