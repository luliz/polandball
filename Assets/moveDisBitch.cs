using UnityEngine;
using System.Collections;

public class moveDisBitch : MonoBehaviour {


	public int velocidade = 1;
	private bool ground = false;
	private bool right = true;
	public GameObject checkGround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("d")){
			transform.Translate(new Vector3(velocidade*Time.deltaTime,0,0));
		}
		if(Input.GetKey("a")){
			transform.Translate(new Vector3(-velocidade*Time.deltaTime,0,0));
		}
		if (Input.GetKeyDown ("w")) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
		}
	}

}
