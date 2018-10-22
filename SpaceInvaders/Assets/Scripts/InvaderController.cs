using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderController : MonoBehaviour {
    ContainerMover containerScript;
    public GameObject m_shot;

    // Use this for initialization
    void Start () {
        containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();

        StartCoroutine(fireBolt());
    }

    IEnumerator fireBolt()
    {
        while (true)
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
