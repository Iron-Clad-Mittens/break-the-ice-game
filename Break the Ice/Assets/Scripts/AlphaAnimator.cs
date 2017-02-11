using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAnimator : MonoBehaviour {

	public Renderer renderer;
	public float speed = .01f;

	private bool isComplete = false;
	private float time = 0; 
	// Use this for initialization
	void Start () {
		Color color = renderer.material.color;
		color.a = 0;
		renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if (isComplete) {
			time += Time.deltaTime;
			if (time > 2) {
				Application.LoadLevel ("OpeningScene");
			}
			return;
		}

		Color color = renderer.material.color;
		color.a += speed;

		if (color.a >= 1) {
			isComplete = true;
		}
			
		renderer.material.color = color;
	}
}
