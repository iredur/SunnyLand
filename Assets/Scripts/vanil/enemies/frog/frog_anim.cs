using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_anim : MonoBehaviour
{
    [SerializeField] public State _state = State.IDLE;
    [SerializeField] AnimUpdate_frog _anim;
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
        _anim.UpdateAnim(_state);
    }
    void UpdateState()
    {
        if (!GetComponent<frog>()._isGrounded)
        {
            if (_rb.velocity.y > 0) _state = State.JUMP;
            else _state = State.FALL;
        }
        else _state = State.IDLE;

    }

    public enum State
    {
        IDLE,
        JUMP,
        FALL
    }
}
