using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private int attackIndex = 0;
    private const int maxAttackIndex = 4;
    private float attackResetTimer = 0.0f;
    private const float attackResetTime = 0.4f; // Thời gian reset về Idle sau khi không nhận được input
    private bool isAttacking = false; // Biến để kiểm tra nếu đang tấn công

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Kiểm tra nếu đang tấn công và animation chưa hoàn tất
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (isAttacking && stateInfo.normalizedTime < 1.0f && stateInfo.IsName("Attack" + attackIndex))
        {
            // Không cho phép thực hiện tấn công mới nếu animation hiện tại chưa kết thúc
            return;
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            attackIndex++;
            if (attackIndex > maxAttackIndex)
                attackIndex = 1;

            animator.SetInteger("attackIndex", attackIndex);
            attackResetTimer = 0.0f; // Reset thời gian đếm ngược
            isAttacking = true; // Đánh dấu trạng thái đang tấn công
        }
        else
        {
            // Tăng bộ đếm thời gian nếu không nhấn chuột
            attackResetTimer += Time.deltaTime;
            if (attackResetTimer > attackResetTime)
            {
                // Reset về Idle khi không có input trong khoảng thời gian quy định
                attackIndex = 0;
                animator.SetInteger("attackIndex", attackIndex);
                isAttacking = false; // Đánh dấu trạng thái không còn tấn công
            }
        }
    }
    public void ResetAttackIndex()
    {
        attackIndex = 0;
    }
}
