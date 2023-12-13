using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    float speed = 10f;
    int damage = 100;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        Wall wall = hitInfo.GetComponent<Wall>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
        else if(wall != null)
        {
            wall.TakeDamage(damage);
        }
        if (hitInfo.name != "VictoryLine")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}