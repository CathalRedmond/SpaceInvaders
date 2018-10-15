using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnScript : MonoBehaviour {
    public GameObject ship;
    float spawnSide;
    Vector3 spawnLocation;
    public float spawnRate = 2.0f;
    float nextSpawn = 0.0f;
    bool spawnShip = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn && spawnShip)
        {
            nextSpawn = Time.time + spawnRate;
            spawnSide = Random.Range(0.0f, 100.0f);
            spawnSide %= 2;
            if (spawnSide == 0.0f)
            {
                spawnLocation = new Vector3(-7.5f, 0.0f, 14.25f);
            }
            else
            {
                spawnLocation = new Vector3(7.5f, 0.0f, 14.25f);
            }
            spawnShip = false;
            Instantiate(ship, spawnLocation, Quaternion.identity);
        }
	}
}
