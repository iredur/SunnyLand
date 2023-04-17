using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    public bool _isGrounded = true;
    public Transform groundCheckLayer;
    public LayerMask groundLayer;
    private float lastAtk;
    [SerializeField] private GameObject player;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGrounded)
        {
            attack();
        }
        groundCheck();
        dirCheck();
    }
    void groundCheck()
    {
        _isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckLayer.position, 0.5f,groundLayer);
        if(colliders.Length > 0)
        {
            _isGrounded = true;
        }
    }

    void attack()
    {
        if (Time.time - lastAtk < 3f)
        {
            return;
        }

        lastAtk = Time.time;
        float x = this.transform.position.x - player.transform.position.x;
        x = x / Mathf.Abs(x);
        _rb.velocity = new Vector2(3 * -x, 7f);
    }

    IEnumerator cooldown()
    {
        Debug.Log("Start");
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("End");
    }

    void dirCheck()
    {
        float x = this.transform.position.x - player.transform.position.x;
        x = x / Mathf.Abs(x);
        this.transform.localScale = new Vector3(x,1,1);
    }
}
