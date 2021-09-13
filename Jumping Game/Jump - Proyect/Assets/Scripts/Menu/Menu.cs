using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private         int         _level      =       1;

    [SerializeField]
    private         Animator    _cameraAnim =       null;

    public void StartGame()
    {
        SceneManager.LoadScene(_level);
    }

    public void Credits()
    {
        _cameraAnim.SetBool("Up", true);
        _cameraAnim.SetBool("Initial", false);
    }
}
