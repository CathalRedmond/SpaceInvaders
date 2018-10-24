using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerMover : MonoBehaviour {

    public float speed;
    public int horizontalMove;
    public float verticalMove;
    public bool collided;
    public bool restarting;
    public bool startShooting;
    public int m_invaderCount;
    PlayerController playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        m_invaderCount = 10;
        collided = false;
        startShooting = false;
        verticalMove = 0.0f;
        restarting = false;
    }

    // Update is called once per frame
    void Update () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        if (collided)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, 0.0f, transform.position.z);
            collided = false;
            startShooting = true;
        }

        if (restarting)
        {
            restarting = false;
        }

        Vector3 movement = new Vector3(horizontalMove * (speed / ( 1 + m_invaderCount * 0.5f)), 0.0f, verticalMove);

        if (playerScript.lives > 0)
        {
            transform.position += movement;
        }

        verticalMove = 0.0f;
	}

    public void restart()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        transform.position = new Vector3(0.0f, 0.0f, 4.75f);

        playerScript.lives--;
        playerScript.restart();
        
        m_invaderCount = 10;

        collided = false;

        for (int i = 0; i < 10; i++)
        {
            GameObject invader = transform.GetChild(i).gameObject;
            invader.SetActive(true);
        }
    }
}
