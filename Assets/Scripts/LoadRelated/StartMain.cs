using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    [SerializeField] private GameObject start;

    [SerializeField] private GameObject select;    
    // Start is called before the first frame update
    private void Awake()
    {
        start.SetActive(true);
        select.SetActive(false);
    }

    public void SelectMenu()
    {
        start.SetActive(false);
        select.SetActive(true);
    }

    public void returnbtn()
    {
        start.SetActive(true);
        select.SetActive(false);
    }
}
