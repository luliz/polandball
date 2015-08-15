using UnityEngine;
using System.Collections;

public class SwordLouco : MonoBehaviour {
	
	private Transform sword;
	public Transform target;
	private Animator animator;
	private Vector3 previousPosition;
	
	bool attacking;
	bool coolingOff;
	public bool atack;
	public float turnSpeed;
	private RaycastHit2D saw;
	public LayerMask enemies;
	int decision;
	private int counter;
	private int timeAfterIsaw = 300;
	public float speed;
	private int facingDirection = 1;
	private bool walkIdiota;
	private int cont = 0;
	public bool coolingoff = false;
	public float x = 0;
	private float y = 0;
	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attacking) {
			y += 1;
			if(y <= 1){
			Debug.Log ("Ouve um atack"); //Visto que a gente vai usar animaçao eu decidi tirar o atack de lulinha que tava dando muito trabalho
			coolingoff = true;
			counter = 0;
			decision = 3;
			}

		}
		else if ((Found () || timeAfterIsaw < 300) && !coolingOff) {
			timeAfterIsaw += 1;
			Follow ();
		}
		else {
			
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
		if (coolingoff) {
			x += Time.deltaTime;
			if (x > 2.5) {
				coolingoff = false;
				attacking = false;
				cont = 0;
				x = 0;
				y = 0;
				previousPosition = target.position;
			}
		} 
		
	}
	
	bool Found() {
		saw = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y-0.1f), Vector2.right * facingDirection, 1.5f, enemies);
		if (saw.transform == target) {
			timeAfterIsaw = 0;
			return true;
		}
		return false;
	}
	
	void Follow() {
		if (!coolingoff) {
			Charge ();
		}
		if (Mathf.Abs (target.position.x - transform.position.x) > 0.6 && !coolingoff) {
			if (transform.position.x > target.position.x) {
				Walk (-1);
			} else {
				Walk (1);
			}
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
		// Troca pra onde o inimigo ta olhando
		facingDirection = -facingDirection;
		
		// Vira o inimigo
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void Charge() {
		if (Mathf.Abs (target.position.x - transform.position.x) < 0.6) {
			cont += 1;
			if (cont > 0 && cont < 2) {
				previousPosition = target.position;
			}
		}
		if ((Mathf.Abs (previousPosition.x - transform.position.x)) > 0.3 && Mathf.Abs (target.position.x - transform.position.x) < 0.6) {
			if (transform.position.x > previousPosition.x) {
				Walk (-1);
			} else {
				Walk (1);
			}
		}
		if (Mathf.Abs (previousPosition.x - transform.position.x) < 0.3) {
			attacking = true;
			animator.SetBool ("walking", false);
		}
	}
}
		



