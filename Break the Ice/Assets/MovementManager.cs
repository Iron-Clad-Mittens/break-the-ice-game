using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    private bool isJumping = false;

    // Use this for initialization
    void Start()
    {
        Player = Instantiate(Player);
        Player.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
            isJumping = true;
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Player.transform.position += movement / 10;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;

        //Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.name == "Platform")
        //{
        //    Debug.Log("platform collide");
        //    isJumping = false;
        //}
    }
}
