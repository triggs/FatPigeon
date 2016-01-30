using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print(this.tag);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //when a mushroom enters the collider, destroy it
        if (other.tag == "Car")
        {

        }
    }
}
