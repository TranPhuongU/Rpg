using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private int attackIndex = 0;
    private int maxAttackIndex = 4;
    public float timeAttack = 0.25f;
    public float m_timeAttack = 0.25f;
    Player player;
    public float originalSpeed;
    bool hasReducedSpeed = false;
    public float reduceSpeed;
    void Start()
    {
        
        animator = GetComponent<Animator>();
        player = FindAnyObjectByType<Player>();
        originalSpeed = player.moveSpeed;
    }
    void Update()
    {
        timeAttack -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeAttack <= 0 ) // Ấn chuột trái
        {
            
            attackIndex++;
            if (!hasReducedSpeed)
            {
                player.moveSpeed -= reduceSpeed;
                hasReducedSpeed = true;
            }
            if (attackIndex > maxAttackIndex)
            {
                attackIndex = 1;
            }
            timeAttack = m_timeAttack;
            animator.SetInteger("attackIndex", attackIndex);  
        }
        if (Input.GetMouseButtonUp(0))
        {
            player.moveSpeed = originalSpeed; // Khôi phục tốc độ ban đầu
            hasReducedSpeed = false; // Cho phép giảm tốc độ lần tiếp theo khi ấn chuột
        }
    }
    public void ResetAttackIndex()
    {
        animator.SetInteger("attackIndex", 0);
    }
}
