using UnityEngine;
using System.Collections;

public class SwordJanissary : MonoBehaviour {

	private Transform sword;
	public Transform target;
	private Animator animator;

	SpriteRenderer expression;
	public Sprite exclamation;
	public Sprite Interrogation;
	int expressionCounter = 50;
	bool attacking;
	bool coolingOff;
	bool isSeeing = false;
	public float turnSpeed;
	private RaycastHit2D saw;
	public LayerMask enemies;
	int decision;
	private int counter;
	private int timeAfterIsaw = 300;
	public float speed;
	private int facingDirection = 1;
	// Use this for initialization
	void Awake () {
		sword = transform.Find ("Sword");
		animator = GetComponent<Animator> ();
		expression = GameObject.Find("Expressions").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (attacking) {
			
			if (sword.rotation.eulerAngles.z <= 270 && sword.rotation.eulerAngles.z != 0) {
				sword.Rotate(new Vector3 (0, 0, -sword.rotation.eulerAngles.z));
				attacking = false;
				coolingOff = true;
				counter = 0;
				decision = 3;
			} else {
				sword.Rotate (new Vector3 (0, 0, Time.deltaTime * -turnSpeed));
			}
		}
		else if ((Found () || timeAfterIsaw < 300) && !coolingOff) {
			timeAfterIsaw += 1;
			Follow ();
		}
		else {
			if (isSeeing && !coolingOff) {


				expression.sprite = Interrogation;
				isSeeing = !isSeeing;
				expressionCounter = 0;
			}
			if (decision == 1) {
				Walk (1);
			}
			else if (decision == 2) {
				Walk (-1);
			}
			else {
				animator.SetBool("walking", false);
			}
			
			counter += 1;

			if (counter > 50) {
				if (coolingOff)
					coolingOff = !coolingOff;
				decision = (int) Random.Range (1, 4);
				counter = 0;
			}

		}

		if (expressionCounter <= 50) {
			if (expressionCounter == 50) {
				expression.sprite = null;
			}
			expressionCounter += 1;
		}
	}

	bool Found() {
		saw = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y-0.1f), Vector2.right * facingDirection, 1.5f, enemies);
		if (saw.transform == target) {
			if (!isSeeing) {
				
				
				expression.sprite = exclamation;
				isSeeing = !isSeeing;
				expressionCounter = 0;
			}
			timeAfterIsaw = 0;
			return true;
		}
		return false;
	}

	void Follow() {

		if (Mathf.Abs (target.position.x - transform.position.x) < 0.3) {
			if (Mathf.Abs (target.position.y - transform.position.y) < 0.3) {
				attacking = true;
				animator.SetBool("walking", false);
			}
			else
				animator.SetBool ("walking", false);
		} else if (transform.position.x > target.position.x) {
			Walk (-1);
		} else {
			Walk (1);
		}
	}

	void Walk(int direction) {
		if (direction == 1 && facingDirection != 1)
			Flip ();
		if (direction == -1 && facingDirection != -1)
			Flip ();
		animator.SetBool ("walking", true);
		transform.Translate (new Vector2 (speed * direction * Time.deltaTime, 0));
	}

	private void Flip(){
		// Troca pra onde o player ta olhando.
		facingDirection = -facingDirection;
		
		// Vira o player .
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		theScale = GameObject.Find ("Expressions").GetComponent<Transform> ().localScale;
		theScale.x *= -1;
		GameObject.Find ("Expressions").GetComponent<Transform> ().localScale = theScale;

	}
	
}
