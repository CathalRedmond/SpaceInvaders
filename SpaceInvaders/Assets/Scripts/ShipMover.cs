using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMover : MonoBehaviour {
    float spawnSide;
    Vector3 spawnLocation;
    public float speed;
    private int horizontalMove;
    private int moveDirection;
    bool moving = false;
    bool firstSpawn = true;
    public bool collided = false;

    // Use this for initialization
    void Start () {
        horizontalMove = 1;
        spawnSide %= 2;
        if (spawnSide == 0.0f)
        {
            spawnLocation = new Vector3(-8.5f, 0.0f, 18.5f);
            moveDirection = 1;
        }
        else
        {
            spawnLocation = new Vector3(8.5f, 0.0f, 18.5f);
            moveDirection = -1;
        }

        transform.position = spawnLocation;

        StartCoroutine(moveShip());
    }

    // Update is called once per frame
    void Update () {
        if (collided)
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator moveShip()
    {
        while (true)
        {
            if (firstSpawn)
            {
                float firstSpawnTime = 5.0f;
                firstSpawn = false;
                moving = true;
                yield return new WaitForSeconds(firstSpawnTime);
            }
            else
            {
                if (moving)
                {
                    if (moveDirection == 1)
                    {
                        Vector3 movement = new Vector3(horizontalMove * speed, 0.0f, 0.0f);
                        transform.position += movement;
                    }
                    else if (moveDirection == -1)
                    {
                        Vector3 movement = new Vector3(horizontalMove * speed, 0.0f, 0.0f);
                        transform.position -= movement;
                    }

                    if (transform.position.x > 8.5f ||
                        transform.position.x < -8.5f)
                    {
                        moving = false;
                    }

                    yield return null;
                }
                else
                {
                    moveDirection *= -1;
                    moving = true;
                    GetComponent<MeshRenderer>().enabled = true;
                    GetComponent<Collider>().enabled = true;
                    collided = false;
                    float SpawnTime = Random.Range(3.0f, 6.0f);
                    yield return new WaitForSeconds(SpawnTime);
                }
            }
        }
    }
}
