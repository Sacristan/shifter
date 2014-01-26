//FIRST line modified

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChunkSpawner : MonoBehaviour {

    public int Levellength = 20;
    public int seed = 10;
    public float maxHeight = 5.0F;
    //public GameObject[] Chunks;

	public PhaseElements[] phaseStyles;
	public static PhaseElements currentPhase { get; private set; }

	private List<Chunk> AllChunks = new List<Chunk>();

	private int currentPhaseIndex;

	public void onLoad() {
		seed = Random.Range (0, 4000);
	}

	void Awake(){

		currentPhase = phaseStyles [0]; //i force it to basic phase until i get more textures
		currentPhaseIndex = 0;
	}

	// Use this for initialization
	void Start () {

		Random.seed = currentPhase.seed;
		Vector3 LastChunkLastCubePos = Vector3.zero;
        for (int i = 0; i < Levellength; i++)
        {

			Vector3 position = LastChunkLastCubePos;
            position += Vector3.up * Random.Range(0.0F, maxHeight);
			GameObject prop = Instantiate(currentPhase.chunksTypes[Random.Range(0, currentPhase.chunksTypes.Length)], position, Quaternion.identity) as GameObject;
            prop.transform.parent = transform;
			AllChunks.Add(prop.GetComponent<Chunk>());
			LastChunkLastCubePos += Vector3.right*(getChunkWidth(prop));
			
        }

	}

	public void Update() {

		if (Input.GetButtonDown ("Shift")) {
			if(currentPhaseIndex == phaseStyles.Length-1){
				switchPhase(phaseStyles[0]);
				currentPhaseIndex = 0;
			}
			else {
				currentPhaseIndex++;
				switchPhase(phaseStyles[currentPhaseIndex]);
			}
		}

		if (currentPhaseIndex == 2) {
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
					enemy.renderer.enabled = false;
			}
		}
		else { 
			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
					enemy.renderer.enabled = true;
			}
		}
			
		}
	
	private float getChunkWidth(GameObject chunk) {

		return chunk.GetComponent<Chunk>().width;

	}

	private void switchPhase(PhaseElements targetPhase) {

		currentPhase = targetPhase;

	}
}
