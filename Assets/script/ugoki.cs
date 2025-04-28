using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float downForce = -5f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canJump = true; // ← ジャンプ可能かどうかのフラグ

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded();
        Move();
        Jump();
        Descend();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal"); // A/Dキー
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            canJump = false; // ジャンプしたらジャンプ不可に
        }
    }

    void Descend()
    {
        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, downForce);
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canJump = true; // 地面に触れていればジャンプ可能に戻す
        }
    }
}