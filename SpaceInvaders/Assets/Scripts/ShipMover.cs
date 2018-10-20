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

    // Use this for initialization
    void Start () {
        horizontalMove = 1;
        spawnSide %= 2;
        if (spawnSide == 0.0f)
        {
            spawnLocation = new Vector3(-7.5f, 0.0f, 14.25f);
            moveDirection = 1;
        }
        else
        {
            spawnLocation = new Vector3(7.5f, 0.0f, 14.25f);
            moveDirection = -1;
        }

        transform.position = spawnLocation;

        StartCoroutine(moveShip());
    }

    // Update is called once per frame
    void Update () {
        //StopCoroutine(moveShip());
    }

    IEnumerator moveShip()
    {
        while (true)
        {
            if (firstSpawn)
            {
                float firstSpawnTime = Random.Range(2.0f, 5.0f);
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

                    if (transform.position.x > 8.0f ||
                        transform.position.x < -8.0f)
                    {
                        moving = false;
                    }

                    yield return null;
                }
                else
                {
                    moveDirection *= -1;
                    moving = true;
                    float SpawnTime = Random.Range(2.0f, 5.0f);
                    yield return new WaitForSeconds(SpawnTime);
                }
            }
        }
    }
}
