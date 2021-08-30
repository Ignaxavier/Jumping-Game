using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private         CameraMovement      move         =       null;

    private         Rigidbody2D         pRB         =       null;

    [SerializeField]
    [Range(0f, 1f)]
    private         float               _xOffset        =       0f;

    [SerializeField]
    [Range(0f, 1f)]
    private         float               _yOffset        =       0f;

    [SerializeField]
    private         float               _magnitude      =       0.5f;

    [HideInInspector]
    public          bool                _shake          =       false;

    private         Vector3             actualPosition  =       new Vector3(0, 0, 0);


    private void Awake()
    {
        move = GetComponent<CameraMovement>();
        pRB = move._player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(move._player != null)
        {
            actualPosition = new Vector3(move.originPosition.x, move._player.transform.position.y + move._playerHeightOffset, move.originPosition.z);
            CameraShakeRoutine(_shake);
        }
    }

    private void CameraShakeRoutine(bool isShake)
    {
        if (isShake && pRB.drag < 1f)
        {
            float x = Random.Range(-_xOffset, _xOffset) * _magnitude;
            float y = Random.Range(-_yOffset, _yOffset) * _magnitude;

            transform.localPosition = new Vector3(x, y, actualPosition.z);
        }
        else
        {
            transform.localPosition = actualPosition;
        }
    }
}
