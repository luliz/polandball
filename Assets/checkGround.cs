using UnityEngine;
using System.Collections;

public class checkGround : MonoBehaviour {
	
	public bool ground = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.name == "ground"){
			ground = true;
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.name == "ground") {
			ground = false;
		}
	}
}
