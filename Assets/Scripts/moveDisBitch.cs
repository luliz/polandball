using UnityEngine;
using System.Collections;

public class moveDisBitch : MonoBehaviour {
	
	
	public float velocidade = 1f;
	private float temporizer = 0f;
	private bool right = true;
	private bool ground = true;
	private bool ceiling;

	public Rigidbody2D myRigidBody2D;

	public bool onRope;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;
	public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		myRigidBody2D = GetComponent<Rigidbody2D> ();
		gravityStore = myRigidBody2D.gravityScale;
		
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("Yvelocity", myRigidBody2D.velocity.y);
		ground = transform.GetComponentInChildren<checkGround>().ground;
		ceiling = transform.GetComponentInChildren<checkCeiling>().ceiling;

		if (onRope) {
			animator.SetBool ("ground", true);
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
		
		if (Input.GetKey (Controls.walkRight)) {
			if (!onRope && ground)
				animator.SetBool ("walking", true);
			else
				animator.SetBool ("walking", false);
			transform.Translate(new Vector3(velocidade*Time.deltaTime,0,0));
			if (!right) {
				Flip ();
			}
		} else if (Input.GetKey (Controls.walkLeft)) {
			if (!onRope && ground)
				animator.SetBool ("walking", true);
			else animator.SetBool ("walking", false);
			transform.Translate(new Vector3(-velocidade*Time.deltaTime,0,0));
			if (right) {
				Flip ();
			}
		} else {
			animator.SetBool ("walking", false);
		}
		if (Input.GetKeyDown (Controls.jump) && (ground || onRope)) {
			myRigidBody2D.AddForce(new Vector2(0f, 2.5f), ForceMode2D.Impulse);
			if (onRope)
				onRope = false;
		}
		if (Input.GetKey(Controls.stickToCeiling) && ceiling == true) {
			temporizer += Time.deltaTime;
			if(temporizer <= 1) {
				animator.SetBool ("ground", true);
				myRigidBody2D.gravityScale = 0;
				myRigidBody2D.velocity = Vector2.zero;
			}
		}
		if(ground == true) {
			temporizer = 0;
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
