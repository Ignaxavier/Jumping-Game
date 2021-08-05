using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Jumping : MonoBehaviour
{
    private         Rigidbody2D     rb;

    [SerializeField]
    [Tooltip("La cama elástica wachin")]
    private         Transform       _spring;

    [Header("Jump")]
    [SerializeField]
    private         string          _jumpInput          =       "jump";
    private         bool            alreadyJump;
    [SerializeField]
    [Range(100f, 500f)]
    [Tooltip("Velocidad de salto")]
    private         float           _jumpVelocity       =       100f;  
    private         int             velocityMultiplier  =       1;

    [Header("Fall")]
    [SerializeField]
    [Range(0, 2f)]
    [Tooltip("Distancia donde empieza a frenar el personaje")]
    private         float           distanceOfSlowFall  =       1.7f;
    [SerializeField]
    [Range(0, 0.5f)]
    [Tooltip("Distancia de frenado que se suma al rebotar en la cama elástica")]
    private         float           _slowFall           =       0f;
    [SerializeField]
    [Tooltip("Multiplicador de velocidad a la caida")]
    private         float           _fallMultiplier     =       2.5f;
    [SerializeField]
    [Range(0f, 0.5f)]
    [Tooltip("Tiempo que se queda suspendido en el aire el personaje antes de caer")]
    private         float           _fallCoutdown       =      0f;
    private         float           fallCoutdownRegister;
    [HideInInspector]
    public          bool            isFalling;

    private         bool            isTouchingSpring;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        fallCoutdownRegister = _fallCoutdown;
    }

    void Update()
    {
        Jump();
        Fall();
        PlusJump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown(_jumpInput) && isTouchingSpring)
        {
            rb.velocity = (Vector2.up * _jumpVelocity * velocityMultiplier * Time.deltaTime) + Vector2.right * rb.velocity.x;
            alreadyJump = true;
        }
    }

    private void Fall()
    {
        if (rb.velocity.y < 0)
        {
            if(_fallCoutdown <= 0)
            {
                isFalling = true;

                rb.velocity += Vector2.up * Physics2D.gravity.y * (_fallMultiplier - 1) * Time.deltaTime;

                if(Vector2.Distance(transform.position, _spring.position) < distanceOfSlowFall)
                {
                    rb.drag = 12f;
                }
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                _fallCoutdown -= Time.deltaTime;
            }
        }
    }

    private void PlusJump()
    {
        if(Vector2.Distance(transform.position, _spring.position) < 1.5f && Input.GetButtonDown(_jumpInput) && alreadyJump)
        {
            velocityMultiplier++;
            distanceOfSlowFall += _slowFall;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 1)
        {
            isTouchingSpring = true;
            isFalling = false;

            rb.drag = 0f;

            if (alreadyJump)
            {
                velocityMultiplier++;
                distanceOfSlowFall += _slowFall;
                _fallCoutdown = fallCoutdownRegister;
                rb.velocity += Vector2.up * _jumpVelocity * velocityMultiplier * Time.deltaTime;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 1)
        {
            isTouchingSpring = false;
        }
    }
}
