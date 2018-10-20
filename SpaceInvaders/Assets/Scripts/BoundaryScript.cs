using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        ContainerMover containerScript = GameObject.Find("Invaders").GetComponent<ContainerMover>();

        if (!containerScript.collided)
        {
            containerScript.horizontalMove = -containerScript.horizontalMove;
            containerScript.verticalMove = -0.5f;
            containerScript.collided = true;
        }
    }
}
