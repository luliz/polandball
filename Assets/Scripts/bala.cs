using UnityEngine;
using System.Collections;

public class bala : MonoBehaviour {

	public GameObject   ponta ;
	public Rigidbody2D bullet;
	public Transform target;
	public Transform target2;

	void Start () {
		bullet = GetComponent<Rigidbody2D> ();

	}
	

	void Update () {
		
	}
	
	public void atirar(){

		target = GameObject.FindWithTag ("Player").transform;
		Rigidbody2D clone;
		clone = (Rigidbody2D)Instantiate (bullet, ponta.transform.position, bullet.transform.rotation);
		if (target.transform.position.x > target2.transform.position.x) {
			clone.AddForce (transform.right * 200);
		}
		if (target.transform.position.x < target2.transform.position.x) {
			clone.AddForce (- transform.right * 200);

		}
			

	}
		

void OnCollisionEnter2D (Collision2D tip){ 
		Destroy(this.gameObject);
	}
	
}
