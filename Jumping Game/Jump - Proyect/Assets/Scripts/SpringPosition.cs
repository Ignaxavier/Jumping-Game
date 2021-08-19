using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPosition : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    [Tooltip("Distancia horizontal limite en positivo")]
    private         float       _positiveLimitX      =       3f;

    [SerializeField]
    [Range(-5, 0)]
    [Tooltip("Distancia horizontal limite en negativo")]
    private         float       _negativeLimitX      =       -3f;

    private         Vector2     myPosition;

    private         bool        alreadyChange        =       false;

    private void Awake()
    {
        myPosition = transform.position;
    }

    private void OnBecameInvisible()
    {
        if (!alreadyChange)
        {
            transform.position = new Vector2(Random.Range(_negativeLimitX, _positiveLimitX), myPosition.y);
            alreadyChange = true;
        }
    }

    private void OnBecameVisible()
    {
        alreadyChange = false;
    }
}
