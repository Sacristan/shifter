using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chunk : MonoBehaviour {
	public int width = 0;
	private Material[] materials;
	
	private PhaseElements phase;
	//public GameObject master;
	int getBGLayer;
	public void Start() {
		phase = ChunkSpawner.currentPhase;
		getBGLayer = LayerMask.NameToLayer ("Background"); //TODO:set that to "Cubes" to be exclusive instead of inclusive
		Random.seed = phase.seed;
		materials = phase.terrainMaterials;
		foreach (MeshRenderer MRenderer in this.GetComponentsInChildren<MeshRenderer>()) {
			if(MRenderer.gameObject.layer != getBGLayer) {
				MRenderer.material = materials[Random.Range(0,materials.Length)];
			}
		}
	}

	public void Update() {

		if (phase != ChunkSpawner.currentPhase) {

			SwitchPhase(ChunkSpawner.currentPhase);

		}

	}

	public void SwitchPhase(PhaseElements _Phase) {
		materials = _Phase.terrainMaterials;
		foreach (MeshRenderer MRenderer in this.GetComponentsInChildren<MeshRenderer>()) {
			if(MRenderer.gameObject.layer != getBGLayer) {
				MRenderer.material = materials[Random.Range(0,materials.Length)];
			}
		}
		this.phase = _Phase;
	}

}