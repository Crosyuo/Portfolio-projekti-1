using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyGrid : MonoBehaviour
{
    public Enemy[] prefabs;
    public int rows = 4;
    public int cols = 14;

    public int health = 100;
    float timer = 0;
    float timeToMove;
    bool direction = false;
    float enemySpeed;

    GameController gameController;

    [SerializeField] GameObject rightW;
    [SerializeField] GameObject leftW;

    private void Awake()
    {
        for (int row = 0; row < this.rows; row++)
        {
            float width = 2.0f * (this.cols - 1);
            float height = 2.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for(int col = 0; col < this.cols; col++)
            {
                Enemy enemy = Instantiate(this.prefabs[row], this.transform);
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                enemy.transform.localPosition = position;
            }
        }

        enemySpeed = 0.25f;
        timeToMove = 0.45f;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (timer > timeToMove)
        {
            timer = 0;
            switch (direction)
            {
                case true:
                    transform.Translate(new Vector3(-enemySpeed, 0, 0));
                    break;
                case false:
                    transform.Translate(new Vector3(enemySpeed, 0, 0));
                    break;
            }
        }

        if (transform.childCount <= 0)
        {
            gameController.gameWon();
        }
    }

    public void wallReached(string directionC)
    {
        if (directionC == "RightCollider")
        {
            rightW.SetActive(false);
            leftW.SetActive(true);
            direction = true;
            transform.Translate(new Vector3(0, -0.2f, 0));
        }
        else if (directionC == "LeftCollider")
        {
            rightW.SetActive(true);
            leftW.SetActive(false);
            direction = false;
            transform.Translate(new Vector3(0, -0.2f, 0));
        }
        else if(directionC == "VictoryLine")
        {
            gameController.gameLost();
        }
    }

    public void enemyAmount()
    {
        if (transform.childCount > 0)
        {
            timeToMove -= 0.008f;
        }
    }
}
