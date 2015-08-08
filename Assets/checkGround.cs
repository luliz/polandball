using UnityEngine;
using System.Collections;

public class checkGround : MonoBehaviour {
	
	public bool ground = false;
	private Animator playerAnimator;
	// Use this for initialization
	void Start () {
		playerAnimator = GetComponentInParent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D (Collider2D col){
		if(col.gameObject.tag == "Jumpable"){
			ground = true;
			playerAnimator.SetBool("ground", true);
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == "Jumpable") {
			ground = false;
			playerAnimator.SetBool("ground", false);
		}
	}
}
