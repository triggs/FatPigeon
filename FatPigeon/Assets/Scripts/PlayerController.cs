using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            print("w was pressed");
        }
        else if (Input.GetKeyDown("a"))
        {
            print("a was pressed");
        }
        else if (Input.GetKeyDown("s"))
        {
            print("s was pressed");
        }
        else if (Input.GetKeyDown("d"))
        {
            print("d was pressed");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
