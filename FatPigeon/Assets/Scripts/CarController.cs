using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * 1.0f * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //when a mushroom enters the collider, destroy it
        if (other.tag == "Tree")
        {
            Destroy(this);
        }
    }
}
