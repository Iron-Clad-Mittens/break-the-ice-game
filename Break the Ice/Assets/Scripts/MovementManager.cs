using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject Player;
	public GameObject Camera;
    public float Speed;

    // Use this for initialization
    void Start()
    {
        Player = Instantiate(Player);
        Player.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
		// Use this to figure out which keys for controller support.
		/*foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}*/

		if (Input.GetKeyDown(KeyCode.Space) && Player.GetComponent<PlayerScript>().canJump )
        {
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
			Player.GetComponent<PlayerScript>().canJump = false;
        }

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			Debug.Log ("Punch");
		}

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Player.transform.position += movement / 10;
		Camera.transform.position = new Vector3 (Player.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
    }
}
