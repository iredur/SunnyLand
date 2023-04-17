using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tc : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private float offset_x = -1.5f;

    private float offset_y = 1.5f;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        this.transform.position = target.transform.position + new Vector3(offset_x, offset_y, 0);
    }
}
