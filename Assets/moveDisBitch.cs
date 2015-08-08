using UnityEngine;
using System.Collections;

public class moveDisBitch : MonoBehaviour {
	
	
	public float velocidade = 1f;
	private bool right = true;
	private bool ground = true;

	public Rigidbody2D myRigidBody2D;

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

		if (onRope) {
			myRigidBody2D.gravityScale = 0;
			myRigidBody2D.velocity = Vector2.zero;
			if(Input.GetKey(Controls.up)){
				myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x,velocidade);
				
			}
			if(Input.GetKey(Controls.down)){
				myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x,-velocidade);
				
			}
		}
		if (!onRope) {
			myRigidBody2D.gravityScale = gravityStore;
		}
		
		if(Input.GetKey(Controls.walkRight)){
			//transform.Translate(new Vector3(velocidade*Time.deltaTime,0,0)); Jeito de Paulao
			myRigidBody2D.velocity = new Vector2(velocidade, myRigidBody2D.velocity.y);
			if(!right){
				Flip();
			}
		}
		if(Input.GetKey(Controls.walkLeft)){
			//transform.Translate(new Vector3(-velocidade*Time.deltaTime,0,0));
			myRigidBody2D.velocity = new Vector2 (-velocidade, myRigidBody2D.velocity.y);
			if(right){
				Flip();
			}
		}
		if (Input.GetKeyDown (Controls.jump) && ground) {
			myRigidBody2D.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
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
