using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Text Tpoint;

    private void Update()
    {
        pointUpdate();
    }

    void pointUpdate()
    {
        Tpoint.text = string.Format("{0}", player.GetComponent<fox>().point);
    }
}
