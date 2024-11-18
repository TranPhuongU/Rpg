﻿using System.Collections;
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
    //public DameAttack dameAttack;

    bool CanMove = true;

    public float dashBoost;
    public float dashTime; // Thời gian dash
    public float cooldownTime; // Thời gian chờ giữa các lần dash
    private float m_dashTime ; // Thời gian còn lại của dash
    private float m_cooldownTime ; // Thời gian chờ còn lại
    bool isDashing;
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
        Dash();
        

    }
    public void Move()
    {
        if (CanMove)
        {
            moveInput.x = Input.GetAxis("Horizontal");
            transform.position += moveInput * moveSpeed * Time.deltaTime;
        }
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
            {
                transform.localScale = new Vector3(-5, 5, 1); 
            }
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
    public void Dash()
    {
        m_cooldownTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && m_dashTime <= 0 && m_cooldownTime <= 0 && isDashing == false)
        {
            // Thực hiện dash
            moveSpeed += dashBoost;
            m_dashTime = dashTime;
            m_cooldownTime = cooldownTime; // Thiết lập thời gian chờ giữa các lần dash
            isDashing = true;
            animator.SetBool("isDash", true);
        }

        // Quản lý khi dash đang diễn ra
        if (m_dashTime > 0)
        {
            m_dashTime -= Time.deltaTime; // Giảm thời gian dash
        }
        else if (m_dashTime <= 0 && isDashing)
        {
            // Kết thúc dash
            moveSpeed -= dashBoost;
            animator.SetBool("isDash", false);
            isDashing = false;
        }
    }

    public HP playerHP;
    public void TakeDamage(int damage)
    {
        playerHP.TakeDame(damage);
    }
   
}
