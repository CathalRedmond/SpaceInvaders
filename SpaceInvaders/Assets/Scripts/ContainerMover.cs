using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMover : MonoBehaviour {

    public float speed;
    public int horizontalMove;
    public float verticalMove;
    public bool collided;
    public bool startShooting;
    public int m_invaderCount;

    void Start()
    {
        m_invaderCount = 11;
        collided = false;
        startShooting = false;
        verticalMove = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        if (collided)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, 0.0f, transform.position.z);
            collided = false;
            startShooting = true;
        }

        Vector3 movement = new Vector3(horizontalMove * (speed / (m_invaderCount * 0.5f)), 0.0f, verticalMove);
        
        transform.position += movement;

        verticalMove = 0.0f;
	}
}
