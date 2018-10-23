using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMover : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float speed;
    PlayerController playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * -speed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerScript.lives--;
            Destroy(gameObject);
            playerScript.restart();
        }

        if (col.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
            ShipMover shipScript = GameObject.Find("Ship").GetComponent<ShipMover>();

            shipScript.collided = true;
        }
    }
}
