using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject Player;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D pl = Player.GetComponent<Rigidbody2D>();
            Player.GetComponent<Rigidbody2D>().AddForce(transform.up * Speed, ForceMode2D.Impulse);
        }
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Player.transform.position += movement / 5;
    }
}
