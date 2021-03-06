using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private         Camera          cam;

    [HideInInspector]
    public          Vector3         originPosition;

    [SerializeField]
    private         Vector3         _limitY         =       new Vector3(0, 0, 0);

    public          GameObject      _player         =       null;

    public          float           _playerHeightOffset     =       0f;

    [SerializeField]
    [Range(5, 10)]
    private         float           _sizeLimit      =       5f;

    [SerializeField]
    private         Transform       _spring         =       null;

    private void Awake()
    {
        originPosition = new Vector3(transform.position.x, _player.transform.position.y + _playerHeightOffset, transform.position.z);

        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if(_player != null)
        {
            if(_player.transform.position.y < originPosition.y)
            {
                transform.position = originPosition;
                cam.orthographicSize = 5;
            }
            else if(_player.transform.position.y > _limitY.y)
            {
                transform.position = _limitY;
            }
            else
            {
                transform.position = new Vector3(transform.position.x, _player.transform.position.y, transform.position.z);

                if (!_player.GetComponent<Jumping>().isFalling)
                {
                    if(cam.orthographicSize <= _sizeLimit)
                    {
                        cam.orthographicSize += Time.deltaTime;
                    }
                }
                else if (_player.GetComponent<Jumping>().isFalling && Vector2.Distance(transform.position, _spring.position) < 23f)
                {
                    if(cam.orthographicSize >= 5)
                    {
                        cam.orthographicSize -= Time.deltaTime * 1.5f;
                    }
                }
            }
        }
        else
        {
            transform.position = _limitY;
        }
    }
}
