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

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        onGround = true;

    }

    [System.Obsolete]
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
            onGround = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(GroundLayer == (1 << other.gameObject.layer))
        {
            onGround = true;
        }
    }
    [System.Obsolete]
    private void FixedUpdate()
    
        {
        movement = new Vector2(moveInput * MoveSpeed, _rigidbody.velocity.y);
        _rigidbody.velocity = movement;
        }
}
