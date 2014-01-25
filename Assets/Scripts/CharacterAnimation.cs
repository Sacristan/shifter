using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	public Texture2D[] idle;
	public Texture2D[] running;
	private float runningCurrentTexture = 0F;
	private int runningCurrentTextureInt = 0;
	public Texture2D[] jumping;
	private int jumpingCurrentTexture;

	//private Rigidbody rigidbody;
	private Material material;

	public void Awake() {
		material = this.GetComponent<MeshRenderer> ().material;
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(Running ());
	}

	public IEnumerator Running() {
		runningCurrentTexture += (float)1/running.Length;
		material.mainTexture = running[runningCurrentTextureInt];
		runningCurrentTextureInt = Mathf.FloorToInt(Mathf.PingPong(runningCurrentTexture, running.Length));
		
		yield return new WaitForSeconds(0.1F);
	}

	public IEnumerator Jumping() {
		
		
		yield return new WaitForSeconds(0.01F);
	}

}
