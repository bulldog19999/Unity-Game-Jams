using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController pc;
    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && pc.getIsDead())
        {
            Debug.Log("You Lose");
            gameOverUpdate();
        }

        if (gameOver && !pc.getIsDead())
        {
            Debug.Log("You Win");
            gameOverUpdate();
        }
    }

    public bool getGameOverStatus()
    {
        return gameOver;
    }

    public void setGameOverStatus(bool gameStatus)
    {
        gameOver = gameStatus;
    }

    private void gameOverUpdate()
    {
        Time.timeScale = 0f;
    }
}
