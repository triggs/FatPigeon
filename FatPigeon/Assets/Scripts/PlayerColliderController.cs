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

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    //print("Despawner hit: " + other.tag);
    //    Destroy(other.gameObject);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
