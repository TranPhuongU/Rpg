using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    public int minDamage;
    public int maxDamage;
    HP hp;
    

    void Start()
    {
        
    }

    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamagePlayer()
    {
        if (player != null) // Kiểm tra null trước khi gọi
        {
            int damage = Random.Range(minDamage, maxDamage);
            player.TakeDamage(damage);
        }
    }
}
