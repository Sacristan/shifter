using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {
	public int width = 0;
	private Material[] materials;
	//public GameObject master;

	public void Start() {
		int getBGLayer = LayerMask.NameToLayer ("Background"); //TODO:set that to "Cubes" to be exclusive instead of inclusive
		Random.seed = ChunkSpawner.currentPhase.seed;
		materials = ChunkSpawner.currentPhase.terrainMaterials;
		foreach (MeshRenderer MRenderer in this.GetComponentsInChildren<MeshRenderer>()) {
			if(MRenderer.gameObject.layer != getBGLayer) {
				MRenderer.material = materials[Random.Range(0,materials.Length)];
			}
		}
	}

}