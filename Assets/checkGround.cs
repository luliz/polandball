﻿using UnityEngine;
using System.Collections;

public class checkGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D (Collider2D col){
		if(col.gameObject.name == "Chao"){
			Debug.Log("Ta no chao");
		}
	}
}
