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

    public void SpawnObstacle(string objectTagName, Vector3 moveDirection, Vector3 startPosition)
    {
        //print("Spawning: " + objectTagName + ", " + moveDirection.x.ToString() + ", " + moveDirection.y.ToString() + ", " + moveDirection.z.ToString());
        Object prefab = Resources.Load(objectTagName);
        //print(prefab);
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        if ((moveDirection.x < 0) && (objectTagName == "Car"))
        {
            obstacle.SendMessage("HorizontalMirror");
            moveDirection = new Vector3(0-moveDirection.x, moveDirection.y, moveDirection.z);
        }
        obstacle.SendMessage("SetStartPosition", startPosition);
        obstacle.SendMessage("SetMoveDirection", moveDirection);
    }
}
