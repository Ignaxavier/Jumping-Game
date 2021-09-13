using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour
{
    [Header("Camera Animator")]
    [SerializeField]
    private         Animator        _camAnim        =       null;


    [Header("Canvas")]

    [SerializeField]
    private         GameObject      _initialCanvas  =       null;

    [SerializeField]
    private         GameObject      _creditsCanvas  =       null;

    void Update()
    {
        if (_camAnim.GetCurrentAnimatorStateInfo(0).IsName("InitialPosition"))
        {
            _initialCanvas.SetActive(true);
        }
        else if (_camAnim.GetCurrentAnimatorStateInfo(0).IsName("Up"))
        {
            _creditsCanvas.SetActive(true);

            if (Input.GetButtonDown("Jump"))
            {
                _camAnim.SetBool("Initial", true);
                _camAnim.SetBool("Up", false);
            }
        }
        else
        {
            _initialCanvas.SetActive(false);
            _creditsCanvas.SetActive(false);
        }
    }
}
