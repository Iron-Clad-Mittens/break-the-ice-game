using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject Camera;
    public float Speed;

    private bool canJump = true;
    private bool canPunch = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        //reset punch
    }

    void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.tag == "Platform")
        {
            canJump = true;
            setLandedAnimation();
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


        if (Input.GetButton("Jump") && canJump)
        {
            this.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
            canJump = false;
            setJumpingAnimation(movement);
        }

		if (Input.GetButton ("Punch") && canPunch) {
			this.GetComponentInChildren<Animator> ().SetTrigger ("doPunch");
		}
        //canPunch = false;
    }

    private void setLandedAnimation()
    {
        this.GetComponentInChildren<Animator>().SetBool("isJumping", false);
        this.GetComponentInChildren<Animator>().SetTrigger("toIdle");
    }

    private void setJumpingAnimation(Vector3 movement)
    {
        this.GetComponentInChildren<Animator>().SetBool("isJumping", true);

    }
    private void setRunningAnimation(Vector3 movement)
    {
        this.GetComponentInChildren<SpriteRenderer>().flipX = (movement.x < 0);

        if (this.GetComponentInChildren<Animator>().GetBool("isJumping"))
        {
            return;
        }

        if (movement.x != 0)
        {
            this.GetComponentInChildren<Animator>().SetTrigger("toWalking");
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetTrigger("toIdle");
        }
    }
}
