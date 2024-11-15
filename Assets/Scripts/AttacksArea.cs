using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacksArea : MonoBehaviour
{
    Player player;
    HP hp;

    public int minDame;
    public int maxDame;
    public bool SwordDame;
    private void Start()
    {
        hp = GetComponent<HP>();
    }
    public void TakeDamage(int damage)
    {
        hp.TakeDame(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SwordDame)
        {
            Debug.Log("danhtrungnguoi");
            int damage = Random.Range(minDame, maxDame);
            collision.GetComponent<Player>().TakeDamage(damage);
            
        }
        if (collision.CompareTag("Enemy") && SwordDame)
        {
            Debug.Log("danhtrungquai");
            int damage = Random.Range(minDame, maxDame);
            collision.GetComponent<Enemy>().TakeDamage(damage);
           
        }
    }
}
