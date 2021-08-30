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

    [Header("Limit")]

    private         Transform       space;

    [SerializeField]
    [Range(-10, 0)]
    private         float           _negativeLimitX     =       -5f;

    [SerializeField]
    [Range(0, 10)]
    private         float           _positiveLimitX     =       5f;

    public         float            _penalizedSlow      =       0f;

    [HideInInspector]
    public         bool             _isMove             =       false;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = GetComponent<Jumping>();

        space = transform;
    }

    void Update()
    {
        if(Input.GetAxis(_movementInput) != 0 && !jump.isDead && canMove)
        {
            rb.velocity = (Vector2.right * Input.GetAxis(_movementInput) * _movementSpeed * 3 * Time.deltaTime) + Vector2.up * rb.velocity.y;

            _isMove = true;
        }
        else
        {
            _isMove = false;
        }
    }

    private void LateUpdate()
    {
        space.position = new Vector2(Mathf.Clamp(transform.position.x, _negativeLimitX, _positiveLimitX), transform.position.y);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            canMove = true;
        }
    }
}
