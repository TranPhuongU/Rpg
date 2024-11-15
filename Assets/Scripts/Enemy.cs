using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    public int minDamage;
    public int maxDamage;
    HP hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<HP>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        hp.TakeDame(damage);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<Player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);// gọi hàm DamagePlayer lặp đi lặp lại
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");// hủy việc lặp lại hàm DamagePlayer
        }
    }
    void DamagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        player.TakeDamage(damage);
    }
}
