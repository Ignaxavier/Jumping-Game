using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private         BoxCollider2D       _collider       =       null;

    public          Animator            _anim           =       null;

    public          AudioSource         _au             =       null;

    private void Awake()
    {
        Disabled();
    }

    public void Enabled()
    {
        _collider.enabled = true;
        _au.enabled = true;
        _anim.SetTrigger("Start");
    }

    public void Disabled()
    {
        _collider.enabled = false;
        _au.enabled = false;
        _anim.SetTrigger("End");
    }
}
