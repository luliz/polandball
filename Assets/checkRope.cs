using UnityEngine;
using System.Collections;

public class checkRope : MonoBehaviour {

	private moveDisBitch thePlayer;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<moveDisBitch> ();
	}
	void OnTriggerStay2D (Collider2D col){
		if (col.name == "Poland" && Input.GetKey (Controls.up)) {
			thePlayer.onRope = true;
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.name == "Poland") {
			thePlayer.onRope = false;
		}
	}

}
