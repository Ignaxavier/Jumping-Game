using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    private         Sounds      sound;

    public          float       _coins      =       0;

    [HideInInspector]
    public          int         coinsAmount =       0;

    [SerializeField]
    private         float       _coinsValue =       0f;

    private void Awake()
    {
        sound = GetComponent<Sounds>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            _coins += _coinsValue;

            coinsAmount++;

            sound.CoinSound();

            Destroy(collision.gameObject);
        }
    }
}
