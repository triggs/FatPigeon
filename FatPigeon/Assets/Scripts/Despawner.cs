using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {

    // Variables

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Despawner Entereds: " + other.tag);
    }

    void OnTriggerExit2D(Collider2D other)
    {
<<<<<<< HEAD
        print("Despawner Exited: " + other.tag);
=======
        //print("Despawner hit: " + other.tag);
>>>>>>> f2575ba538bb6311fcb67b96cf348f7df3e13601
        Destroy(other.gameObject);
    }
}
