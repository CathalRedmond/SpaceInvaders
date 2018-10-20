using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunkerHit : MonoBehaviour {

    private Transform m_bunkerTransform;

    void Start()
    {
        m_bunkerTransform = GetComponent<Transform>();
    }

	void onTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shot"))
        {
            m_bunkerTransform.localScale -= m_bunkerTransform.localScale/10;
        }
    }
}
