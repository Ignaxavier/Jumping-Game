using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private          Animator            _anim           =       null;

    private void Awake()
    {
        Nothing();    
    }

    public void Enabled()
    {
        _anim.SetBool("Active", true);
    }

    public void Disabled()
    {
        _anim.SetBool("Active", false);
    }

    public void Nothing()
    {
        _anim.SetTrigger("Nothing");
    }
}
