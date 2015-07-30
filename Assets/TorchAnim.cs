using UnityEngine;
using System.Collections;

public class TorchAnim : MonoBehaviour {

	float timeRemaining = 0.6f;

	public Sprite torch01;
	public Sprite torch02;
	public Sprite torch03;
	public Sprite torch04;
	public Sprite torch05;
	public Sprite torch06;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeRemaining += Time.deltaTime;

		if (timeRemaining >0 && timeRemaining <0.1) {
			transform.GetComponent<SpriteRenderer>().sprite = torch01;
		}

		if (timeRemaining >0.1 && timeRemaining <0.2) {
			transform.GetComponent<SpriteRenderer>().sprite = torch02;
		}

		if (timeRemaining >0.2 && timeRemaining <0.3) {
			transform.GetComponent<SpriteRenderer>().sprite = torch03;
		}

		if (timeRemaining >0.3 && timeRemaining <0.4) {
			transform.GetComponent<SpriteRenderer>().sprite = torch04;
		}

		if (timeRemaining >0.4 && timeRemaining <0.5) {
			transform.GetComponent<SpriteRenderer>().sprite = torch05;
		}

		if (timeRemaining >0.5 && timeRemaining <0.6) {
			transform.GetComponent<SpriteRenderer>().sprite = torch06;
		}

		if (timeRemaining > 0.6) {
			timeRemaining = 0;
		}
	}
}
