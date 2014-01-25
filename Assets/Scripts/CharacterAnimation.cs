using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	public Texture2D[] idle;
	public Texture2D[] running;
	private float runningCurrentTexture;

	public Texture2D[] jumping;
	private int jumpingCurrentTexture;

	private Material material;

	public void Awake() {

		material = this.GetComponent<MeshRenderer> ().material;
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine (Running ());
	}

	public IEnumerator Running() {

		material.mainTexture = running [Mathf.FloorToInt(runningCurrentTexture)];
		runningCurrentTexture = Mathf.PingPong(runningCurrentTexture, running.Length);

		yield return new WaitForSeconds(0.01F);
	}

	public IEnumerator Jumping() {
		
		
		yield return new WaitForSeconds(0.01F);
	}

}
