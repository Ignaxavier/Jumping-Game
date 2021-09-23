using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(BoxCollider2D), typeof(AudioSource))]
public class Obstacle : MonoBehaviour
{
    private         SpriteRenderer      sr                  =       null;

    private         AudioSource         au                  =       null;

    [SerializeField]
    private         ParticleSystem      _explosion          =       null;

    [SerializeField]
    private         int                 _layerCollider      =       0;

    [SerializeField]
    private         GameObject          _coin               =       null;

    [SerializeField]
    private         int                 _coinAmount         =       0;

    [SerializeField]
    [Range(0f, 1.5f)]
    [Tooltip("Offset de position al spawnear monedas")]
    private         float               _coinSpawnOffset    =       0f;

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

            for (int i = 0; i < _coinAmount; i++)
            {
                GameObject coin = Instantiate(_coin, new Vector2(transform.position.x + Random.Range(0f, _coinSpawnOffset), transform.position.y + Random.Range(0f, _coinSpawnOffset)), Quaternion.identity);
            }

            Destroy(this.gameObject, 2f);
        }
    }
}
