using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHead : MonoBehaviour
{
    [SerializeField]
    private         Rigidbody2D         _playerRB       =       null;

    [SerializeField]
    private         Animator            _playerAnim     =       null;

    [SerializeField]
    private         Jumping             _playerJump     =       null;

    [SerializeField]
    private         Sounds              _playerSounds   =       null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 13)
        {
            if(collision.GetComponent<SpriteRenderer>().enabled == true)
            {
                _playerRB.velocity = new Vector3(0, 0, 0);
                _playerAnim.SetTrigger("Hit");
                _playerSounds.DeadSound();

                if(_playerJump.velocityMultiplier > 1)
                {
                    _playerJump.velocityMultiplier--;
                }
            }
        }
    }
}
