using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDamage : MonoBehaviour
{
    private         Rigidbody2D         rb;

    [Header("Objects")]
    [SerializeField]
    private         Fire          _upDamageObject         =       null;
    [SerializeField]
    private         Fire          _downDamageObject       =       null;

    [Header("Velocitys")]
    [SerializeField]
    [Tooltip("Velocidad en que se activa el daño de salto")]
    [Range(0, 1000)]
    private         float               _upDamageVelocity       =       60f;
    [SerializeField]
    [Tooltip("Velocidad en que se activa el daño de caida")]
    [Range(-1000, 0)]
    private         float               _downDamageVelocity     =       -85f;

    [Header("Camera Shake")]
    [SerializeField]
    private         CameraShake         _camShake               =       null;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _upDamageObject.Nothing();
        _downDamageObject.Nothing();
    }

    void Update()
    {
        Upper();
        Downer();
    }

    private void Downer()
    {
        if (rb.velocity.y < _downDamageVelocity)
        {
            _downDamageObject.Enabled();
            _camShake._shake = true;
            _upDamageObject.Nothing();
        }
        else if (rb.velocity.y > _downDamageVelocity)
        {
            _camShake._shake = false;
            _downDamageObject.Disabled();
        }
    }

    private void Upper()
    {
        if (rb.velocity.y > _upDamageVelocity)
        {
            _upDamageObject.Enabled();
            _camShake._shake = true;
            _downDamageObject.Nothing();
        }
        else if (rb.velocity.y < _upDamageVelocity)
        {
            _camShake._shake = false;
            _upDamageObject.Disabled();
        }
    }
}
