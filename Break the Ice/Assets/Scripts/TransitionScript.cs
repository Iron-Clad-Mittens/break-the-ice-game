using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionScript : MonoBehaviour {

	public string NextScene;
	public float WaitSeconds = 2.0f;
	public bool triggerOnCollision = false;

	private bool running = true;
	private float elapsedTime = 0;
	// Use this for initialization
	void Start () {
		if (triggerOnCollision) {
			running = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!running) {
			return;
		}
		
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= WaitSeconds) {
			Application.LoadLevel (NextScene);
		}
	}

	void OnCollisionEnter2D(Collision2D colli){
		if (colli.gameObject.tag == "Player") {
			running = true;
		}
	}
}
