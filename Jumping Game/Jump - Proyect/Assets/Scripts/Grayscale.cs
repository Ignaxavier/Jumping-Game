using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grayscale : MonoBehaviour
{
    private         SpriteRenderer          sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void GrayScaleEnabled()
    {
        sr.material.SetFloat("_GrayscaleAmount", 1);
    }

    public void GrayScaleDisabled()
    {
        sr.material.SetFloat("_GrayscaleAmount", 0);
    }
}
