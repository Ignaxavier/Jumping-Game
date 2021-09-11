using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(BoxCollider2D), typeof(AudioSource))]
public class Obstacle : MonoBehaviour
{
    private         SpriteRenderer      sr              =       null;

    private         AudioSource         au              =       null;

    [SerializeField]
    private         ParticleSystem      _explosion      =       null;

    [SerializeField]
    private         LayerMask           _layerCollider  =       0;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        au = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _layerCollider)
        {
            sr.enabled = false;
            _explosion.Play();
            au.Play();

            Destroy(this.gameObject, 2f);
        }
    }
}
