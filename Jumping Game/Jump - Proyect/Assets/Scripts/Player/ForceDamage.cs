using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDamage : MonoBehaviour
{
    private         Rigidbody2D         rb;

    [Header("Objects")]
    [SerializeField]
    private         GameObject          _upDamageObject         =       null;
    [SerializeField]
    private         GameObject          _downDamageObject       =       null;

    [Header("Velocitys")]
    [SerializeField]
    [Tooltip("Velocidad en que se activa el daño de salto")]
    [Range(0, 1000)]
    private         float               _upDamageVelocity       =       60f;
    [SerializeField]
    [Tooltip("Velocidad en que se activa el daño de caida")]
    [Range(-1000, 0)]
    private         float               _downDamageVelocity     =       -85f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _upDamageObject.SetActive(false);
        _downDamageObject.SetActive(false);
    }

    void Update()
    {
        Upper();
        Downer();
    }

    private void Downer()
    {
        if(rb.velocity.y < _downDamageVelocity)
        {
            _downDamageObject.SetActive(true);
        }
        else if (rb.velocity.y > _downDamageVelocity)
        {
            _downDamageObject.SetActive(false);
        }
    }

    private void Upper()
    {
        if (rb.velocity.y > _upDamageVelocity)
        {
            _upDamageObject.SetActive(true);
        }
        else if (rb.velocity.y < _upDamageVelocity)
        {
            _upDamageObject.SetActive(false);
        }
    }
}
