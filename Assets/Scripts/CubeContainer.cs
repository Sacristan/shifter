using UnityEngine;
using System.Collections;

public class CubeContainer : MonoBehaviour {

    public int Levellength = 20;
    public int seed = 10;
    public float maxHeight = 5.0F;
    public GameObject[] Cubes;



	// Use this for initialization
	void Start () {

        Random.seed = seed;

        for (int i = 0; i < Levellength; i++)
        {

            Vector3 position = Vector3.right * i;
            position += Vector3.up * Random.Range(0.0F, maxHeight);
            GameObject prop = Instantiate(Cubes[Random.Range(0, Cubes.Length)], position, Quaternion.identity) as GameObject;
            prop.transform.parent = transform;

        }

	}
	
	// Update is called once per frame
	void Update () {

        transform.position += (Vector3.left * Time.time) * Time.deltaTime;

	}
}
