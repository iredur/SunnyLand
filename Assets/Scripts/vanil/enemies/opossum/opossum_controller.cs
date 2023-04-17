using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossum_controller : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float moveSpeed = 5;
    public int patrolDestination;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (patrolDestination == 0)
        {
            _rb.velocity = Vector2.right * -moveSpeed;
            if (Mathf.Abs(this.transform.position.x - patrolpoints[0].position.x) < .2f)
            {
                patrolDestination = 1;
                this.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        if (patrolDestination == 1)
        {
            _rb.velocity = Vector2.right * moveSpeed;
            if (Mathf.Abs(this.transform.position.x - patrolpoints[1].position.x) < .2f)
            {
                patrolDestination = 0;
                this.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
