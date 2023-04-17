using UnityEngine;

namespace vanil.player
{
    public class fox_controller : MonoBehaviour
    {
        public Rigidbody2D _rb;
        private float _f_force = 8;
        private float fall = 2.5f;
        private float lj = 2f;
        public bool _isGrounded = true;
        public Transform groundCheckLayer;
        public LayerMask groundLayer;

        public GameObject manager;
        // Start is called before the first frame update
        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            Application.targetFrameRate = 300;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            BetterJump();
            groundCheck();
            pauseDetect();
        }
        void Movement()
        {
            float Move = Input.GetAxisRaw("Horizontal");
            _rb.velocity = new Vector2(Move * GetComponent<fox>().speed, _rb.velocity.y);
            if (Move < 0) this.transform.localScale = new Vector3(-1, 1, 1);
            else if (Move > 0) this.transform.localScale = new Vector3(1, 1, 1);
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                Jump();
            }
        }

        public void Jump()
        {
            _rb.AddForce(Vector2.up * _f_force, ForceMode2D.Impulse);
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

        void BetterJump()
        {
            if (_rb.velocity.y < 0)
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (fall - 1)*Time.deltaTime;
            else if(_rb.velocity.y>0&&!Input.GetButton("Jump"))
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (lj - 1)*Time.deltaTime;
        }

        void pauseDetect()
        {
            if(Input.GetKeyDown(KeyCode.Escape)) manager.GetComponent<ButtonHandle>().Pause();
        }

    }
}
