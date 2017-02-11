using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject Player;
	public GameObject Camera;
    public float Speed;
    private bool isGrounded = false;

    // Use this for initialization
    void Start()
    {
        Player = Instantiate(Player);
        Player.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {


		if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
			isGrounded = false;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Player.transform.position += movement / 10;
		Camera.transform.position = new Vector3 (Player.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
    }

	void FixedUpdate ()
	{
		isGrounded = true;
		return;

		Vector3 plPosition = Player.transform.position;
		RaycastHit2D hit = Physics2D.Raycast(new Vector3(plPosition.x, plPosition.y - 1, plPosition.z), -transform.up, 0);

		if (!isGrounded && hit.collider != null && hit.collider.gameObject.name == "Platform") {
			isGrounded = true;
			Debug.Log (hit.distance);
		}

		if (!isGrounded)
			return;
		
		//Debug.Log (hit.collider.gameObject.name);
		//Debug.Log (hit.distance);
	}
}
