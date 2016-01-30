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
        print("Despawner Exited: " + other.tag);
        Destroy(other.gameObject);
    }
}
