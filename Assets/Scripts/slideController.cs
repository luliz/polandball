using UnityEngine;
using System.Collections;

public class slideController : MonoBehaviour {

	private Animator animator;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (animator.GetCurrentAnimatorStateInfo(0).IsName("cameraAnimation7"))
				Application.LoadLevel(1);
			else
				animator.SetTrigger ("advance");
		}
	}
}
