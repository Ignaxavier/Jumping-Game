using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private         Jumping         player;

    public          float           _maxHeight      =       0f;

    public          float           _timeLive       =       0f;

    public          float           _score          =       0f;

    [SerializeField]
    [Tooltip("Valor que se multiplica al puntaje")]
    private         float           scoreMultiplyer =       1.5f;

    [SerializeField]
    private         Grayscale[]     grayscaleObjects;

    [HideInInspector]
    public          bool            isSlow          =       false;

    private         bool            isFinish        =       false;

    private void Awake()
    {
        grayscaleObjects = FindObjectsOfType<Grayscale>();

        player = FindObjectOfType<Jumping>();
    }

    private void Update()
    {
        Grayscale();
        LiveTime();

        if (player.isDead & !isFinish)
        {
            _score = Mathf.Round((_timeLive + _maxHeight) * scoreMultiplyer);
            
            Debug.Log("Has sobrevivido " + Mathf.Round(_timeLive) + " segundos y has alcanzado los " + _maxHeight + " metros.");
            Debug.Log("Tu puntaje final es de " + _score);
            isFinish = true;
        }
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

    private void LiveTime()
    {
        if(player.isStartJump && !player.isDead)
        {
            _timeLive += Time.deltaTime;
        }
    }
}
