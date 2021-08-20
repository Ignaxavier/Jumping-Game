using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private         Jumping         player;

    public          float           _timeLive       =       0f;

    [SerializeField]
    private         Grayscale[]     grayscaleObjects;

    public          bool            isSlow          =       false;

    private void Awake()
    {
        grayscaleObjects = FindObjectsOfType<Grayscale>();

        player = FindObjectOfType<Jumping>();
    }

    private void Update()
    {
        Grayscale();
        LiveTime();
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
        else if (player.isStartJump && player.isDead)
        {
            Debug.Log("Has aguantado " + Mathf.Round(_timeLive) + " Segundos");
        }
    }
}
