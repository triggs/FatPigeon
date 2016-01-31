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
        var sirPigeon = this.transform.parent.gameObject;
        if (other.tag == "Tree")
        {
            // print("Tree has left the pigeon.");
            sirPigeon.SendMessage("SetCollideWithTree", false);
        }
        if (other.tag == "Cat")
        {
            // print("Cat has left the pigeon.");
            sirPigeon.SendMessage("SetCollideWithCat", false);
        }
        if (other.tag == "Crack")
        {
            // print("Crack has left the pigeon.");
            sirPigeon.SendMessage("SetCollideWithCrack", false);
        }
        if (other.tag == "Car")
        {
            // print("Car has left the pigeon.");
            sirPigeon.SendMessage("SetCollideWithLeftCar", false);
        }
        if (other.tag == "RightCar")
        {
            // print("Right car has left the pigeon.");
            sirPigeon.SendMessage("SetCollideWithRightCar", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var sirPigeon = this.transform.parent.gameObject;
        //var sirPigeon = (PlayerController)sirPigeon;

        ////Destroy(other.gameObject);
        if (other.tag == "Tree")
        {
            //print("Tree collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithTree", true);
        }
        else if (other.tag == "Cat")
        {
            //print("Cat collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithCat", true);
        }
        else if (other.tag == "Car")
        {
            sirPigeon.SendMessage("SetCollideWithLeftCar", true);
        }
        else if (other.tag == "Crack")
        {
            //print("Crack collides with pigeon.");
            sirPigeon.SendMessage("SetCollideWithCrack", true);
        }
        else if (other.tag == "RightCar")
        {
            print("RightCarCollide");
            sirPigeon.SendMessage("SetCollideWithRightCar", true);
        }
    }
}
