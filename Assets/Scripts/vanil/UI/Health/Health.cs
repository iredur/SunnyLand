using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private Image totalHealth;
    [SerializeField] private Image currHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        totalHealth.fillAmount = player.GetComponent<fox>().maxHP/10;
    }

    // Update is called once per frame
    void Update()
    {
        currHealth.fillAmount = player.GetComponent<fox>().HP/10;
    }
}
