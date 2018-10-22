using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotMover : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float speed;
    ContainerMover containerScript;
    PlayerController playerScript;

    void Start()
    {
        containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * -speed;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // player loses life
        }
        if (col.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
            ShipMover shipScript = GameObject.Find("Ship").GetComponent<ShipMover>();

            shipScript.collided = true;
        }
    }
}
