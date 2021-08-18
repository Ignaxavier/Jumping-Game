using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private         BoxCollider2D       _collider;

    public          Animator            _anim;

    public void ColliderEnabled()
    {
        if (!_collider.enabled)
        {
            _collider.enabled = true;
        }
        else if (_collider.enabled)
        {
            _collider.enabled = false;
        }
    }
}
