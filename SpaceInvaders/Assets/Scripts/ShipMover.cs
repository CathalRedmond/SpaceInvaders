using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {
    float spawnSide;
    Vector3 spawnLocation;
    public float speed;
    public int horizontalMove;
    bool moving = false;

    // Use this for initialization
    void Start () {
        spawnSide %= 2;
        if (spawnSide == 0.0f)
        {
            spawnLocation = new Vector3(-7.5f, 0.0f, 14.25f);
        }
        else
        {
            spawnLocation = new Vector3(7.5f, 0.0f, 14.25f);
        }

        transform.position = spawnLocation;
        //StartCoroutine(moveShip());
    }

    // Update is called once per frame
    void Update () {
        StartCoroutine(moveShip());
    }

    IEnumerator moveShip()
    {
        yield return new WaitForSeconds(2);

        if (!moving)
        {
            Vector3 movement = new Vector3(horizontalMove * speed, 0.0f, 0.0f);
            transform.position += movement;
        }
        else if (!moving)
        {
            Vector3 movement = new Vector3(horizontalMove * speed, 0.0f, 0.0f);
            transform.position -= movement;
        }

        if (transform.position.x >= 7.5f && transform.position.x <= -7.5f)
        {
            moving = true;
        }
        yield return new WaitForSeconds(2);

    }
}
