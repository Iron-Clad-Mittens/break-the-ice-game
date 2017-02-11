using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAnimator : MonoBehaviour {

	public Text text;
	public string message = "Hello World;";
	public float delayBetweenChar = 0.5f;

	private int index = 0;
	private float elapsedTime = 0f;
	// Use this for initialization
	void Start () {
		if (text != null) {
			text.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (text == null) {
			return;
		}

		elapsedTime += Time.deltaTime;
		if (elapsedTime >= delayBetweenChar) {
			elapsedTime = 0;
			text.text += message.Substring (index, 1);
			index++;
			if (index == message.Length) {
				text = null;
			}
		}

	}
}
