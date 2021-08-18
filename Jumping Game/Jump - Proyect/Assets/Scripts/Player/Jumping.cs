using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Jumping : MonoBehaviour
{
    private         Rigidbody2D     rb;

    private         GameManager     gm;

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
    private         float           _distanceOfSlowFall  =       1.7f;

    [SerializeField]
    [Tooltip("Altura minima donde el freno se habilita")]
    private         float           _distanceOfSlowWorks =       12f;

    private         bool            slowFallAvalible     =       false;

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

    [HideInInspector]
    public          bool            isDead              =      false;

    private         bool            isTouchingSpring;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        gm = FindObjectOfType<GameManager>();

        fallCoutdownRegister = _fallCoutdown;
    }

    void Update()
    {
        Jump();
        Fall();
        PlusJump();
        ExtraBooleans();
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

                if(Vector2.Distance(transform.position, _spring.position) < _distanceOfSlowFall && slowFallAvalible && transform.position.y - 1.5f > _spring.position.y + 0.5f)
                {
                    rb.drag = 20f;

                    gm.isSlow = true;
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
            _distanceOfSlowFall += _slowFall;
        }
    }

    private void ExtraBooleans()
    {
        if (!slowFallAvalible)
        {
            if(transform.position.y > _distanceOfSlowWorks)
            {
                slowFallAvalible = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            gm.isSlow = false;

            isTouchingSpring = true;
            isFalling = false;

            rb.drag = 0f;

            if (alreadyJump)
            {
                velocityMultiplier++;
                _distanceOfSlowFall += _slowFall;
                _fallCoutdown = fallCoutdownRegister;
                rb.velocity += Vector2.up * _jumpVelocity * velocityMultiplier * Time.deltaTime;
            }
        }

        if(collision.gameObject.layer == 8)
        {
            isDead = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            isTouchingSpring = false;
        }
    }
}