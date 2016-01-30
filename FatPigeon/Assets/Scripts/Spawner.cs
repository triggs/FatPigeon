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
        print("Spawning: " + objectTagName);
        Object prefab = Resources.Load(objectTagName);
        print(prefab);
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        obstacle.SendMessage("SetMoveDirection", moveDirection);
    }
}
