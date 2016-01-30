using UnityEngine;
using System.Collections;
/**
 * Derek Browne 05391903
 * 
 * Spawns Bugs
 * 
 * */
public class Spawner : MonoBehaviour {
	
	//visible vars
	public GameController gameController;
    //private vars
    private float NextSpawn;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void SpawnObstacle(string objectTagName, Vector3 moveDirection)
    {
        print(objectTagName);
		GameObject obstacle = Instantiate((Resources.Load(objectTagName)), transform.position, Quaternion.identity) as GameObject;
        obstacle.SendMessage("SetMoveDirection", moveDirection);
    }
}
