using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{

    public float obstacleSpawnRate; //objects spawn after x milliseconds
	public float obstacleMoveSpeed;

    public float foregroundMoveSpeed;
	public float middlegroundMoveSpeed;
	public float backgroundMoveSpeed;
    
	public Spawner rightSpawner;
    public Spawner leftSpawner;
    public float nextObstacleSpawnTime;
    public bool gameOver = false;
    private float gameOverTimeout = 10.0f;
    public float gameTimer = 30.0f;
    private ScoreController scoreController;
    public float obstaclePositionGround = -3.5f; // Player, Cat Crack
    public float obstaclePositionMiddle = -0.5f; // Car Right
    public float obstaclePositionTop = 1; // Car Left
    public float obstaclePositionTree = 0f; //Tree 


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
        obstacleSpawnRate = 1.5f;
        nextObstacleSpawnTime = 3.0f;
        scoreController = new ScoreController();
        scoreController.ShowScore();
		obstacleMoveSpeed = 1.0f;
		foregroundMoveSpeed = 0.2f;
		middlegroundMoveSpeed = 1.0f;
		backgroundMoveSpeed = 0.08f;
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
                Vector3 moveDirection = new Vector3(-foregroundMoveSpeed, 0.0f);
                //spawn new obstacles
                if (spawnTag.Contains("Car"))
                {
                    //Random Side
                    if (UnityEngine.Random.value > 0.5f)
                    {
                        //rightSide Car
                        rightSpawner.SpawnObstacle("Car", moveDirection, new Vector3(rightSpawner.transform.position.x, obstaclePositionMiddle, 0));
                    }
                    else
                    {
                        //leftSide car 
                        moveDirection = new Vector3(obstacleMoveSpeed, 0.0f);
                        leftSpawner.SpawnObstacle("Car", moveDirection, new Vector3(leftSpawner.transform.position.x, obstaclePositionTop, 0));
                    }
                }
                else
                {
                    //Lower chances of seeing trees since we're not using them.
                    if (spawnTag == "Tree")
                    {
                        if (UnityEngine.Random.value > 0.6f)
                            spawnTag = "Tree";
                        else
                            spawnTag = GetObstacleToSpawn();
                    }
                        if (spawnTag == "Tree")
                    {
                        rightSpawner.SpawnObstacle(spawnTag, moveDirection, new Vector3(rightSpawner.transform.position.x, obstaclePositionTree, 0));
                    }
                    else
                    {
                        rightSpawner.SpawnObstacle(spawnTag, moveDirection, new Vector3(rightSpawner.transform.position.x, obstaclePositionGround, 0));
                    }
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

    public void AddScore(int value)
    {
        scoreController.ChangeScore(value);
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
