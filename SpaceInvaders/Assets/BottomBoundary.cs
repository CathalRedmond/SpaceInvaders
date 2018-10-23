using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBoundary : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        ContainerMover containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();

        if (other.gameObject.tag == "Invader")
        {
            if (!containerScript.restarting)
            {
                containerScript.restarting = true;
                containerScript.restart();
            }
        }
    }
}
