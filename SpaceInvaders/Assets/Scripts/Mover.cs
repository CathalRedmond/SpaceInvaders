﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float speed;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.velocity = transform.forward * speed;
    } 
}