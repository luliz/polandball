using UnityEngine;
using System.Collections;

public class moveDisBitch : MonoBehaviour {
	
	
	public int velocidade = 1;
	private bool right = true;
	private bool ground = true;

	private Rigidbody2D myRigidBody2D;

	public bool onRope;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	// Use this for initialization
	void Start () {
		myRigidBody2D = GetComponent<Rigidbody2D> ();
		gravityStore = myRigidBody2D.gravityScale;
		
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
		if (Input.GetKeyDown (KeyCode.Space) && ground && !onRope) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
		}
		if (onRope) {
			myRigidBody2D.gravityScale = 0f;
			if(Input.GetKey("w")){
				transform.Translate(new Vector3(0,velocidade*Time.deltaTime,0));

			}
			if(Input.GetKey("s")){
				transform.Translate(new Vector3(0,-velocidade*Time.deltaTime,0));
				
			}
		}
		if (!onRope) {
			myRigidBody2D.gravityScale = gravityStore;
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
