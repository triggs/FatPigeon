using UnityEngine;
using System.Collections;

public class PlayerColliderController : MonoBehaviour {

    // Variables

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        //print("Despawner hit: " + other.tag);
        // Destroy(other.gameObject);
        var sirPigeon = this.transform.parent.gameObject;
        sirPigeon.SendMessage("SetCollideWithCat", false);
        sirPigeon.SendMessage("SetCollideWithCrack", false);
        sirPigeon.SendMessage("SetCollideWithLeftCar", false);
        sirPigeon.SendMessage("SetCollideWithRightCar", false);
        sirPigeon.SendMessage("SetCollideWithTree", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var sirPigeon = this.transform.parent.gameObject;
        //var sirPigeon = (PlayerController)sirPigeon;

        ////Destroy(other.gameObject);
        if (other.tag == "Tree")
        {
            print("Tree collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithTree", true);
        }
        else if (other.tag == "Cat")
        {
            print("Cat collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithCat", true);
        }
        else if (other.tag == "Car")
        {
            print("Car collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithLeftCar", true);
        }
        else if (other.tag == "Crack")
        {
            print("Crack collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithCrack", true);
        }
        else if (other.tag == "Tree")
        {
            sirPigeon.SendMessage("SetCollideWithRightCar", true);
        }
    }
}
