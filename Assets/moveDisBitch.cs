using UnityEngine;
using System.Collections;

public class moveDisBitch : MonoBehaviour {
	
	
	public int velocidade = 1;
	private bool right = true;
	private bool ground = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ground = transform.GetComponentInChildren<checkGround>().ground;
		if(Input.GetKey("d")){
			transform.Translate(new Vector3(velocidade*Time.deltaTime,0,0));
			if(!right){
				Flip();
			}
		}
		if(Input.GetKey("a")){
			transform.Translate(new Vector3(-velocidade*Time.deltaTime,0,0));
			if(right){
				Flip();
			}
		}
		if (Input.GetKeyDown ("w") && ground) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
		}
	}
	private void Flip(){
		// Troca pra onde o player ta olhando.
		right = !right;
		
		// Vira o player .
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
}
