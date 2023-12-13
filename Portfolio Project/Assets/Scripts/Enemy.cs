using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemeyGrid enemyGrid;
    GameController gameController;

    public int health = 100;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Awake()
    {
        enemyGrid = GameObject.FindGameObjectWithTag("Invaders").GetComponent<EnemeyGrid>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        InvokeRepeating("FireLaser", Random.Range(1f, 6f), 1f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.name == "Enemy3(Clone)")
        {
            gameController.pointsChange(75);
        }
        else if (gameObject.name == "Enemy2(Clone)")
        {
            gameController.pointsChange(50);
        }
        else if (gameObject.name == "Enemy1(Clone)")
        {
            gameController.pointsChange(25);
        }

        enemyGrid.enemyAmount();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        enemyGrid.wallReached(collider.name);
    }

    private void FireLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, -Vector2.up);

        if (hit.collider.tag != "Enemy")
        {
            if(Random.Range(0, 7) <= 1)
            {
                GameObject enemyBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
