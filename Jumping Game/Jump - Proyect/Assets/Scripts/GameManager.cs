using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Jumping player;

    [SerializeField]
    private Grayscale[] grayscaleObjects;

    public bool isSlow = false;

    private void Awake()
    {
        grayscaleObjects = FindObjectsOfType<Grayscale>();

        player = FindObjectOfType<Jumping>();
    }

    private void Update()
    {
        Grayscale();

    }

    private void Grayscale()
    {
        if (isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].StartGrayscaleRoutine();
            }
        }
        else if (!isSlow)
        {
            for(int i = 0; i < grayscaleObjects.Length; i++)
            {
                grayscaleObjects[i].ResetGrayscaleRoutine();
            }
        }
    }
}
