using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private         Animator        anim;
    private         Jumping         jump;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        jump = GetComponent<Jumping>();
    }

    private void Update()
    {
        #region Fall
        if (!jump.isFalling)
        {
            anim.SetBool("Up", true);
            anim.SetBool("Down", false);
        }
        else if (jump.isFalling)
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", true);
        }
        #endregion

        if (jump.isDead)
        {
            anim.SetTrigger("Dead");
        }

    }

}
