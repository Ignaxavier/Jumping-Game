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

    private         Fire                upFire                  =       null;
    private         Fire                downFire                =       null;

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

        upFire = _upDamageObject.GetComponent<Fire>();
        downFire = _downDamageObject.GetComponent<Fire>();
    }

    void Update()
    {
        if(rb.drag < 2)
        {
            Upper();
            Downer();
        }
        else
        {
            downFire._anim.SetTrigger("Nothing");
            upFire._anim.SetTrigger("Nothing");
        }
    }

    private void Downer()
    {
        if (upFire._anim.GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
        {
            if (rb.velocity.y < _downDamageVelocity)
            {
                downFire._anim.SetTrigger("Start");
                _camShake._shake = true;
                upFire._anim.SetTrigger("Nothing");
            }
            else if (rb.velocity.y > _downDamageVelocity)
            {
                downFire._anim.SetTrigger("End");
                _camShake._shake = false;
            }
        }
    }

    private void Upper()
    {
        if (downFire._anim.GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
        {
            if (rb.velocity.y > _upDamageVelocity)
            {
                upFire._anim.SetTrigger("Start");
                _camShake._shake = true;
                downFire._anim.SetTrigger("Nothing");
            }
            else if (rb.velocity.y < _upDamageVelocity)
            {
                _camShake._shake = false;
                upFire._anim.SetTrigger("End");
            }
        }
    }
}
