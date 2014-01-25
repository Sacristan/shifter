using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {
	public int width = 0;
	public Material[] materials;
	public GameObject master;

	public void Start() {
		Random.seed = master.GetComponent<CubeContainer>().seed;
		foreach (MeshRenderer MRenderer in this.GetComponentsInChildren<MeshRenderer>()) {

			MRenderer.material = materials[Random.Range(0,materials.Length)];
		
		}
	}

}