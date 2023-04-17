using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using vanil.player;

public class fox : MonoBehaviour
{
    public float HP = 3;
    public float speed = 5;
    public float point = 0;
    public float subHP = 0;
    public float maxHP = 3;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject manager;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        HP = maxHP;
    }

    private void Update()
    {
        HPUpdate();
        checkHurt();
        HP_check();
    }

    void HPUpdate()
    {
        if (subHP == 3)
        {
            subHP = 0;
            HP += 1;
            maxHP += 1;
        }
    }

    public void takeDamage()
    {
        HP--;
        StartCoroutine(Invul());
    }

    IEnumerator Invul()
    {
        Physics2D.IgnoreLayerCollision(9,10,true);
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Physics2D.IgnoreLayerCollision(9,10,false);
        GetComponent<player_collision>()._isHurt = false;
    }

    void checkHurt()
    {
        if (GetComponent<player_collision>()._isHurt == true) GetComponent<fox_controller>().enabled = false;
        else GetComponent<fox_controller>().enabled = true;
    }

    public void knockedBack(GameObject hit)
    {
        if (GetComponent<player_collision>()._isHurt == true)
        {
            float dir = hit.transform.position.x - this.transform.position.x;
            float x = dir / MathF.Abs(dir);
            _rb.velocity = Vector2.left * 1.5f * x;
        }
    }

    public void HP_check()
    {
        if (HP == 0)
        {
            manager.GetComponent<Win>().Lost();
            manager.GetComponent<SoundHandle>().over.Play();
            Destroy(this);
        }
    }
    
}
