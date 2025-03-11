using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float moveInput;
    private Vector2 movement;
    public float MoveSpeed = 5f;
    

    public float jumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool onGround;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        onGround = true;

    }

    
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetBool("isRunning", moveInput != 0);


        if(moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            onGround = false;
        }

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(GroundLayer == (1 << other.gameObject.layer))
        {
            
            onGround = true;
            animator.SetBool("isJumping", false);
        }
    }
    


    private void FixedUpdate()
    
        {
        movement = new Vector2(moveInput * MoveSpeed, _rigidbody.linearVelocity.y);
        animator.SetBool("isRunning", moveInput != 0);
        _rigidbody.linearVelocity = movement;
        }
}
