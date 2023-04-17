using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State=frog_anim.State;

public class AnimUpdate_frog : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void UpdateAnim(State state)
    {
        for (int i = 0; i <= (int)State.FALL; i++)
        {
            string stateName = ((State)i).ToString();
            if (state == (State)i)
            {
                anim.SetBool(stateName, true);
            }
            else anim.SetBool(stateName, false);
        }
    }
}
