using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMover : MonoBehaviour {

    public float speed;
    public int horizontalMove;
    public float verticalMove;
    public bool collided;

    void Start()
    {
        collided = false;
    }

    // Update is called once per frame
    void Update () {
        if (collided)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, 0.0f, transform.position.z);
            collided = false;
        }

        Vector3 movement = new Vector3(horizontalMove * speed, 0.0f, verticalMove);
        
        transform.position += movement;

        verticalMove = 0.0f;
	}
}
