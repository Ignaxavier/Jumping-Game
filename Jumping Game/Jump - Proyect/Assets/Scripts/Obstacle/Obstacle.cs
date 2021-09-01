using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    private         SpriteRenderer      sr              =       null;

    [SerializeField]
    private         ParticleSystem      _explosion      =       null;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            sr.enabled = false;
            _explosion.Play();

            Destroy(this, 2f);
        }
    }
}
