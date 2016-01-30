using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{

    public float obstacleSpawnRate; //objects spawn after x milliseconds
    public float obstacleMoveSpeed = 1.0f;
    public Spawner rightSpawner;
    public Spawner leftSpawner;
    public float nextObstacleSpawnTime;
    public int liveCount = 3; // Misses or Bads Lose player 1 Life
    public bool gameOver = false;
    private float gameOverTimeout = 10.0f;
    public float gameTimer = 30.0f;
    private ScoreController scoreController;

    public enum PassFailTime
    {
        Pass,
        Fail
    }

    public enum GameObjects
    {
        RightCar,
        LeftCar,
        Cat,
        Tree,
        Crack
    }
    
    void Start()
    {
        rightSpawner = GameObject.FindGameObjectWithTag("RightSpawner").GetComponent<Spawner>();
        leftSpawner = GameObject.FindGameObjectWithTag("LeftSpawner").GetComponent<Spawner>();
        obstacleSpawnRate = 2.0f;
        nextObstacleSpawnTime = 3.0f;
        scoreController = new ScoreController();
        scoreController.ShowScore();
    }

    /// <summary>
    /// Game Loop
    /// </summary>
    void Update()
    {
        if (gameOver)
        {
            //when game over, load again after a time 
            if (Time.time >= gameOverTimeout)
            {
                SceneManager.LoadScene(0);
            }
        }
        else {

            if (Input.GetKeyDown("p"))
            {
                scoreController.ChangeScore(1);
            }
            if (Input.GetKeyDown("l"))
            {
                scoreController.ChangeScore(-1);
            }
            if (Input.GetKeyDown("o"))
            {
                gameOver = false;
                EndGame();
            }

            //otherwise galeplay !!!
            if (Time.time > nextObstacleSpawnTime)
            {
                string spawnTag = GetObstacleToSpawn();
                Vector3 moveDirection = new Vector3(-obstacleMoveSpeed, 0.0f);
                //spawn new obstacles
                if (spawnTag.Contains("Car"))
                {
                    //Random Side
                    if (UnityEngine.Random.value > 0.5f)
                    {
                        //rightSide Car
                        rightSpawner.SpawnObstacle("Car", moveDirection);
                    }
                    else
                    {
                        //leftSide car 
                        moveDirection = new Vector3(obstacleMoveSpeed, 0.0f);
                        leftSpawner.SpawnObstacle("Car", moveDirection);
                    }
                }
                else
                {
                    rightSpawner.SpawnObstacle(spawnTag, moveDirection);
                }
                nextObstacleSpawnTime = Time.time + obstacleSpawnRate;
            }
        }
    }

    private string GetObstacleToSpawn()
    {
        var randomObjectIndex = UnityEngine.Random.Range(0, 5);
        GameObjects obstacle = (GameObjects)randomObjectIndex;
        return obstacle.ToString();
    }

    /// <summary>
    /// Increase the difficulty of the game
    /// </summary>
    /// <param name="difficulty"></param>
    void SetDifficulty(float difficulty)
    {

    }

    /// <summary>
    /// Return a time value for the Pass/Fail rank of the action performed/not performed
    /// </summary>
    /// <param name="pft"></param>
    /// <returns></returns>
    public float GetPassFailTime(PassFailTime pft)
    {
        switch (pft)
        {
            case PassFailTime.Pass:
                return 3.0f;
            case PassFailTime.Fail:
                return -3.0f;
        }
        //unhandled time?
        return 0;
    }

    /// <summary>
    /// Finish The Game, Display Score, Fade to Black
    /// </summary>
    public void EndGame()
    {
        //game over, display text and set reload timer 
        if (!gameOver)
        {
            gameOver = true;
            gameOverTimeout = Time.time + gameOverTimeout;
            scoreController.ShowScore(false);
            scoreController.ShowEndScore(true);
        }
    }
}
