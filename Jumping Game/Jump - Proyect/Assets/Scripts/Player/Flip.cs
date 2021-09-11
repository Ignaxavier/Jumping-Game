using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private         SpriteRenderer      sr      =       null;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            sr.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            sr.flipX = false;
        }
    }
}
