using UnityEngine;
using System.Collections;

public class ClimbRope : MonoBehaviour {

	public bool roping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(roping == true) {

			if (Input.GetKeyDown ("w")) {
				transform.Translate(new Vector3(0,0,0.5f*Time.deltaTime));
			}
			
			if (Input.GetKeyDown ("s")) {
				transform.Translate(new Vector3(0,0,-0.5f*Time.deltaTime));
			}
		}
	
	}

	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.tag == "Rope"){
			transform.GetComponent<Rigidbody2D>().gravityScale = 0;
			roping = true;
		}
	}

	void OnTriggerExit2D (Collider2D col){
		if(col.gameObject.tag == "Rope"){
			transform.GetComponent<Rigidbody2D>().gravityScale = 1;
			roping = false;
		}
	}
}
