using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRegister : MonoBehaviour
{
    public      float           _generalScore       =       0;

    public      int             _levelMultiplyer    =       0;

    public      static       ScoreRegister   Instance;

    private void Awake()
    {
        if(ScoreRegister.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            _levelMultiplyer++;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
