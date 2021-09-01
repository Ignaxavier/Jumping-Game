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

    [SerializeField]
    [Range(0, 2f)]
    [Tooltip("Tolerancia de espaciado entre la posición actual y la siguiente")]
    private         float       _tolerance           =       1.5f;

    private         Vector2     actualPosition;

    private         Vector2     nextPosition;

    private         bool        alreadyChange        =       false;

    private void Awake()
    {
        actualPosition = transform.position;
        nextPosition = new Vector2(Random.Range(_negativeLimitX, _positiveLimitX), actualPosition.y);
    }

    private void OnBecameInvisible()
    {
        if (!alreadyChange)
        {
            CheckPosition();
            transform.position = nextPosition;
            actualPosition = transform.position;
            alreadyChange = true;
        }
    }

    private void OnBecameVisible()
    {
        CheckPosition();
        alreadyChange = false;
    }

    private void CheckPosition()
    {
        if(Vector2.Distance(actualPosition, nextPosition) <= _tolerance) 
        {
            nextPosition = new Vector2(Random.Range(_negativeLimitX, _positiveLimitX), actualPosition.y);
        }
    }
}
