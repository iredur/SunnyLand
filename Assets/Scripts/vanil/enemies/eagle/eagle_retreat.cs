using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle_retreat : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            retreat();
        }
    }
    
    IEnumerator Retreat()
    {
        //Physics2D.IgnoreLayerCollision(9,10,true);
        GetComponent<eagle>().enabled = false;
        for (int i = 0; i < 2; i++)
        {
            _rb.velocity = Vector2.up * speed;
            yield return new WaitForSeconds(1f);
        }

        _rb.velocity = Vector2.zero;
        GetComponent<eagle>().enabled = true;
        //Physics2D.IgnoreLayerCollision(9,10,false);
    }
    
    public void retreat()
    {
        StartCoroutine(Retreat());
    }
}
