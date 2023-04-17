using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;
using vanil.player;

public class fox_anim : MonoBehaviour
{
    [SerializeField] public PlayerState _playerState = PlayerState.IDLE;
    [SerializeField] AnimUpdate _anim;
    Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
        _anim.UpdateAnim(_playerState);
    }
    void UpdateState()
    {
        if (GetComponent<player_collision>()._isHurt)
        {
            _playerState = PlayerState.HURT;
        }

        else if (!GetComponent<fox_controller>()._isGrounded)
        {
            if (_rb.velocity.y > 0) _playerState = PlayerState.JUMP;
            else _playerState = PlayerState.FALL;
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                _playerState = PlayerState.RUN;
            }
            else _playerState = PlayerState.IDLE;
        }

    }

    public enum PlayerState
    {
        IDLE,
        RUN,
        JUMP,
        FALL,
        HURT
    }
}
