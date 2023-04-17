using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerState=fox_anim.PlayerState;

public class AnimUpdate : MonoBehaviour
{   
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void UpdateAnim(PlayerState playerState)
    {
        for (int i = 0; i <= (int)PlayerState.HURT; i++)
        {
            string stateName = ((PlayerState)i).ToString();
            if (playerState == (PlayerState)i)
            {
                anim.SetBool(stateName, true);
            }
            else anim.SetBool(stateName, false);
        }
    }
}
