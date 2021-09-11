using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private         Animator        anim                    =       null;

    [SerializeField]
    private         Transform       _spring                 =       null;

    [SerializeField]
    private         float           _timeVisible            =       0f;

    private         float           timeVisibleRegister     =       0f;

    [HideInInspector]
    public          bool            see                     =       false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        timeVisibleRegister = _timeVisible;
    }

    private void Update()
    {
        transform.position = new Vector2(_spring.position.x, transform.position.y);

        if (see)
        {
            if(_timeVisible <= 0)
            {
                _timeVisible = timeVisibleRegister;
                anim.SetBool("IsEnabled", false);
                see = false;
            }
            else
            {
                anim.SetBool("IsEnabled", true);
                _timeVisible -= Time.deltaTime;
            }
        }
    }
}
