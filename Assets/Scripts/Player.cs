using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool m_isGround;
    public float JumpForce;
    public float moveSpeed;
    private Rigidbody2D rb;
    public Vector3 moveInput;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        animatorMove();
        QuayMatPlayer();
        Jump();

    }
    public void Move()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }
    public void animatorMove()
    {
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }
    public void QuayMatPlayer()
    {
        if(moveInput.x != 0)
        {
            if (moveInput.x > 0 )
            {
                transform.localScale = new Vector3(5, 5, 1);
            }
            else
                transform.localScale = new Vector3(-5, 5, 1);
        }
    }
    public void Jump()
    {
        bool isJumpKeyPress = Input.GetKeyDown(KeyCode.Space);
        if (isJumpKeyPress && m_isGround)
        {
            rb.AddForce(Vector2.up * JumpForce);
            m_isGround = false;
            animator.SetBool("isJump", true);
            animator.SetBool("isGround", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGround = true;
            animator.SetBool("isGround", true );
            animator.SetBool("isJump", false);
        }
    }
}
