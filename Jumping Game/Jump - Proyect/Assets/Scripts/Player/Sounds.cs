using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private         AudioSource     au;

    [SerializeField]
    private         AudioClip       _jumpSound      =       null;

    [SerializeField]
    private         AudioClip       _coinSound      =       null;

    [SerializeField]
    private         AudioClip       _deadSound      =       null;

    [HideInInspector]
    public          bool            alreadyPlay     =       false;

    private void Awake()
    {
        au = GetComponent<AudioSource>();
    }

    public void JumpSound()
    {
        au.clip = _jumpSound;
        au.Play();
    }

    public void CoinSound()
    {
        au.clip = _coinSound;
        au.Play();
    }

    public void DeadSound()
    {
        if (!alreadyPlay)
        {
            au.clip = _deadSound;
            au.Play();
            alreadyPlay = true;
        }
    }
}
