using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {

	private Animator animator;
	private AudioSource ASource;

	public AudioClip walk;

	public AudioClip[] Jumps;

	public void Awake() {
		animator = this.GetComponent<Animator> ();
		ASource = this.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		animator.SetFloat("speedx", this.rigidbody.velocity.x);
		animator.SetFloat("speedy", this.rigidbody.velocity.y);
		Vector3 velocity = this.rigidbody.velocity;
		if (Mathf.Abs(velocity.x)>0.1 &&Mathf.Abs(velocity.y)<0.1  && !ASource.audio.isPlaying) {
			ASource.audio.Play();
		}
		if ((Mathf.Abs(velocity.x)<0.1 || Mathf.Abs(velocity.y)>0.1)  && ASource.audio.isPlaying) {
			ASource.audio.Stop();
		}
		if (Input.GetButtonDown("Jump")) {
			//ASource.audio.clip = Jumps[Random.Range(0,Jumps.Length)];
			ASource.audio.PlayOneShot(Jumps[Random.Range(0,Jumps.Length)]);
		}
	}

}
