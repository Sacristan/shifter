//FIRST line modified

using UnityEngine;
using System.Collections;

public class ChunkSpawner : MonoBehaviour {

    public int Levellength = 20;
    public int seed = 10;
    public float maxHeight = 5.0F;
    //public GameObject[] Chunks;

	public PhaseElements[] phaseStyles;
	public static PhaseElements currentPhase { get; private set; }

	void Awake(){

		currentPhase = phaseStyles [0]; //i force it to basic phase until i get more textures

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
			LastChunkLastCubePos += Vector3.right*(getChunkWidth(prop));
			
        }

	}
	
	private float getChunkWidth(GameObject chunk) {

		return chunk.GetComponent<Chunk>().width;

	}
}
