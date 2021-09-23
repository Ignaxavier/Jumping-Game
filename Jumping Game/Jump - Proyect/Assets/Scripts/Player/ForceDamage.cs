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

    [Header("Hit Head")]
    [SerializeField]
    private         GameObject          _hit                    =       null;


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
        CameraShake();
    }

    private void Downer()
    {
        if (rb.velocity.y < _downDamageVelocity)
        {
            _downDamageObject.Enabled();
            _upDamageObject.Nothing();
            _hit.SetActive(false);
        }
        else if (rb.velocity.y > _downDamageVelocity)
        {
            _hit.SetActive(true);
            _downDamageObject.Disabled();
        }
    }

    private void Upper()
    {
        if (rb.velocity.y > _upDamageVelocity)
        {
            _upDamageObject.Enabled();
            _downDamageObject.Nothing();
            _hit.SetActive(false);
        }
        else if (rb.velocity.y < _upDamageVelocity)
        {
            _hit.SetActive(true);
            _upDamageObject.Disabled();
        }
    }

    private void CameraShake()
    {
        if(rb.velocity.y < _downDamageVelocity || rb.velocity.y > _upDamageVelocity)
        {
            _camShake._shake = true;
        }
        else if(rb.velocity.y > _downDamageVelocity || rb.velocity.y < _upDamageVelocity)
        {
            _camShake._shake = false;
        }
    }
}