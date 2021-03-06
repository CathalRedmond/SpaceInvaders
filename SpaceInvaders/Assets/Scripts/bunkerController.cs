﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunkerController : MonoBehaviour {

    private Transform m_transform;
    private Vector3 shrink;
    private int m_bunkerHitCounter;

    void Start()
    {
        m_transform = GetComponent<Transform>();
        shrink = m_transform.localScale / 20;
        m_bunkerHitCounter = 0;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
            m_transform.localScale -= shrink;
            m_bunkerHitCounter += 1;
            PlayerController playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
            playerScript.bunkerHitSound.Play();
        }
        if (m_bunkerHitCounter >= 10)
        {
            Destroy(this.gameObject);
        }
    }


}


