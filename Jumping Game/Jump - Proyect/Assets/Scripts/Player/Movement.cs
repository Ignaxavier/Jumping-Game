using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private         Rigidbody2D     rb;

    private         Jumping         jump;

    [Header("Movement")]

    [SerializeField]
    private         string          _movementInput      =       "Horizontal";

    [SerializeField]
    [Range(20, 100)]
    private         float           _movementSpeed      =       0f;

    private         bool            canMove             =       false;

    [SerializeField]
    private         TrailRenderer   _trail              =       null;

    [SerializeField]
    private         float           _timeToTrailEnable  =       2f;

    private         float           timerTrial          =       0f;

    private         bool            isVisible           =       true;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jumping>();
    }

    void Update()
    {
        if(Input.GetAxis(_movementInput) != 0 && !jump.isDead && canMove)
        {
            rb.velocity = (Vector2.right * Input.GetAxis(_movementInput) * _movementSpeed * 3 * Time.deltaTime) + Vector2.up * rb.velocity.y;
        }
    }

    private void LateUpdate()
    {
        if (isVisible)
        {
            if (timerTrial >= _timeToTrailEnable)
            {
                _trail.enabled = true;
            }
            else
            {
                timerTrial += Time.deltaTime;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            canMove = true;
        }
    }

    private void OnBecameInvisible()
    {
        _trail.enabled = false;
        timerTrial = 0;
        isVisible = false;

        if(transform.position.x > 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y);
        }
        else if(transform.position.x < 0)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y);
        }
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }
}
