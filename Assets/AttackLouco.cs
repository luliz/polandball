using UnityEngine;
using System.Collections;

public class AttackLouco : MonoBehaviour {

	private bool atack;
	private Transform sword;
	// Use this for initialization
	void Start () {
		sword = transform;
	}
	
	// Update is called once per frame
	void Update () {
		atack = GetComponentInParent<SwordLouco> ().atack;
		Debug.Log (atack);
		if (atack) {
			if (sword.rotation.eulerAngles.z <= 270 && sword.rotation.eulerAngles.z != 0) {
				sword.Rotate(new Vector3 (0, 0, -sword.rotation.eulerAngles.z));
			} else {
				sword.Rotate (new Vector3 (0, 0, Time.deltaTime * -500));
			}
		}
	}
}
