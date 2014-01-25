//FIRST line modified

using UnityEngine;
using System.Collections;

public class CubeContainer : MonoBehaviour {

    public int Levellength = 20;
    public int seed = 10;
    public float maxHeight = 5.0F;
    public GameObject[] Chunks;



	// Use this for initialization
	void Start () {

        Random.seed = seed;
		Vector3 LastChunkLastCubePos = Vector3.zero;
        for (int i = 0; i < Levellength; i++)
        {

			Vector3 position = LastChunkLastCubePos;
            position += Vector3.up * Random.Range(0.0F, maxHeight);
			GameObject prop = Instantiate(Chunks[Random.Range(0, Chunks.Length)], position, Quaternion.identity) as GameObject;
            prop.transform.parent = transform;
			LastChunkLastCubePos += Vector3.right*(getChunkWidth(prop));

        }

	}
	
	private float getChunkWidth(GameObject chunk) {

		return chunk.GetComponent<Chunk>().width;

	}
}
