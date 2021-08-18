using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grayscale : MonoBehaviour
{
    private         SpriteRenderer          sr;

    [SerializeField]
    private         float                   _duration       =       1f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        SetGrayscale(1);
    }

    public void StartGrayscaleRoutine()
    {
        //StartCoroutine(GrayscaleRoutine(_duration, true));
        sr.material.SetFloat("_GrayscaleAmount", 1);
    }

    public void ResetGrayscaleRoutine()
    {
        //StartCoroutine(GrayscaleRoutine(_duration, false));
        sr.material.SetFloat("_GrayscaleAmount", 0);
    }


    private IEnumerator GrayscaleRoutine(float duration, bool isGrayscale)
    {
        float time = 0;

        while(duration > time)
        {
            float durantionFrame = Time.deltaTime;
            float ratio = time / duration;
            float grayAmount = isGrayscale
                ? ratio
                : 1 - ratio;

            SetGrayscale(grayAmount);
            time += durantionFrame;
            yield return null;
        }
        SetGrayscale(isGrayscale ? 1 : 0);
    }

    public void SetGrayscale(float amount = 1)
    {
        sr.material.SetFloat("_GrayscaleAmount", amount);
    }
}
