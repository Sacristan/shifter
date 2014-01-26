using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	private Animator animator;

	public void Awake() {
		animator = this.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		animator.SetFloat("speedx", this.rigidbody.velocity.x);
		animator.SetFloat("speedy", this.rigidbody.velocity.y);
	}

}
