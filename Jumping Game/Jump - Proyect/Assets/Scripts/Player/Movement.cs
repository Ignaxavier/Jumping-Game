using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private         Rigidbody2D     rb;

    [SerializeField]
    private         string          _movementInput      =       "Horizontal";

    [SerializeField]
    [Range(20, 100)]
    private         float           _movementSpeed      =       0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetAxis(_movementInput) != 0)
        {
            rb.velocity = (Vector2.right * Input.GetAxis(_movementInput) * _movementSpeed * Time.deltaTime) + Vector2.up * rb.velocity.y;
        }
    }
}
