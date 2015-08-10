using UnityEngine;
using System.Collections;

public class checkCeiling : MonoBehaviour {

	public bool ceiling = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D (Collider2D col){
		if(col.gameObject.tag == "Stickable"){
			ceiling = true;
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == "Stickable") {
			ceiling = false;
		}
	}
}
