using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    [SerializeField]
    private         GameObject      _coinPrefab         =       null;

    [SerializeField]
    private         Vector2         _fristPoint         =       new Vector2(0, 0);

    [SerializeField]
    private         Vector2         _finalPoint         =       new Vector2(0, 0);

    [SerializeField]
    private         int             _coinsAmount        =       0;

    private void Awake()
    {
        for (int i = 0; i < _coinsAmount; i++)
        {
            float x = Random.Range(_fristPoint.x, _finalPoint.x);
            float y = Random.Range(_fristPoint.y, _finalPoint.y);

            GameObject coin = Instantiate(_coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
