using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderController : MonoBehaviour {
    ContainerMover containerScript;
    PlayerController playerScript;
    public GameObject m_shot;
    Coroutine shootingRoutine;
    bool stop = false;

    // Use this for initialization
    void Start () {
        containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        shootingRoutine = StartCoroutine(fireBolt());
    }

    void Update()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        if (playerScript.lives <= 0)
        {
            stop = true;
            StopCoroutine(shootingRoutine);
        }
    }

    IEnumerator fireBolt()
    {
        while (!stop)
        {
            if (containerScript.startShooting)
            {
                Instantiate(m_shot, gameObject.transform.position, gameObject.transform.rotation);
            }

            float shootDelay = Random.Range(2.0f, 8.0f);
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
