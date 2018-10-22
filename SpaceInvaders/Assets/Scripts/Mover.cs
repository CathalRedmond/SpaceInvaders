using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float speed;
    private PlayerController playerScript;



    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * speed;

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Invader")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);

            ContainerMover containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();

            containerScript.m_invaderCount--;
            PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
            playerScript.score += 100;

            playerScript.invaderKilledSound.Play();
        }
        if (col.gameObject.tag == "Ship")
        {
            Destroy(gameObject);
            ShipMover shipScript = GameObject.Find("Ship").GetComponent<ShipMover>();

            shipScript.collided = true;

            PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
            playerScript.score += 500;


            playerScript.invaderKilledSound.Play();
        }
    }
}
