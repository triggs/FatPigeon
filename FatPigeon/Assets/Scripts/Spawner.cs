using UnityEngine;
using System.Collections;
/**
 * Derek Browne 05391903
 * 
 * Spawns Bugs
 * 
 * */
public class Spawner : MonoBehaviour
{	
    //private vars
    private float NextSpawn;

    void Start()
    {
    }

    public void SpawnObstacle(string objectTagName, Vector3 moveDirection)
    {
		GameObject obstacle = Instantiate((Resources.Load(objectTagName)), transform.position, Quaternion.identity) as GameObject;
        obstacle.SendMessage("SetMoveDirection", moveDirection);
    }
}
