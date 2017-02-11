using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject Camera;
    public float Speed;

    private bool canJump = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "Platform")
        {
            canJump = true;
            setLandedAnimation(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
        }
    }

    private void movement()
    {
        // Use this to figure out which keys for controller support.
        /*foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
		{
			if (Input.GetKeyDown(kcode))
				Debug.Log("KeyCode down: " + kcode);
		}*/

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        this.transform.position += movement / 10;
        Camera.transform.position = new Vector3(this.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);

        setRunningAnimation(movement);


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
            canJump = false;
            setJumpingAnimation(movement);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Punch");
        }



    }

    private void setLandedAnimation(Vector3 movement)
    {
        this.GetComponentInChildren<Animator>().SetTrigger("toIdle");
    }

    private void setJumpingAnimation(Vector3 movement)
    {
        if (movement.x == 0)
        {
            this.GetComponentInChildren<Animator>().SetTrigger("toIdleJump");
        }

    }
    private void setRunningAnimation(Vector3 movement)
    {
        if (movement.x != 0)
        {
            this.GetComponentInChildren<Animator>().SetTrigger("toWalking");
        }
        else
        {
            //this.GetComponentInChildren<Animator> ().SetTrigger ("toIdle");
        }

        this.GetComponentInChildren<SpriteRenderer>().flipX = (movement.x < 0);

    }
}

