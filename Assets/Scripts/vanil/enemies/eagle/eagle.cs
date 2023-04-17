using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject target;

    private bool aim = true;

    private bool allowCheck = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        flip();
        checkAim();
    }
    void movement()
    {
        if (aim)
        {
            Vector3 dir = target.transform.position - this.transform.position;
            dir = dir.normalized;
            this.transform.position += dir * speed * Time.deltaTime;
        }
    }

    void checkAim()
    {
        aim = false;
        Vector3 dir = target.transform.position - this.transform.position;
        if (Mathf.Abs(dir.sqrMagnitude) < 70&&true||allowCheck)
        {
            aim = true;
        }
    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            Vector3 dir = target.transform.position - this.transform.position;
//            dir = dir.normalized;
//            aim = false;
//            this.transform.position -= dir * speed * Time.deltaTime;
//            allowCheck = false;
//            if(Mathf.Abs(dir.sqrMagnitude)>45)
//            {
//                allowCheck = true;
//            }
//            
//        }
//    }

    void flip()
    {
        int x = 1;
        if (this.transform.position.x > target.transform.position.x)
        {
            x = 1;
        }
        else if (this.transform.position.x < target.transform.position.x)
        {
            x = -1;
        }
        this.transform.localScale = new Vector3(x, 1, 1);
    }
}
