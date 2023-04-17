using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject WinUI;
    [SerializeField] private GameObject LoseUI;
    // Start is called before the first frame update
    private void Awake()
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        Physics2D.IgnoreLayerCollision(10,10,true);
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(10,10,true);
    }

    public void Completed()
    {
        WinUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Lost()
    {
        GetComponent<AudioSource>().Stop();
        LoseUI.SetActive(true);
        Time.timeScale = 0;
    }
}
