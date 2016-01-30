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

    void OnCollisionEnter2D(Collision2D coll)
    {
        print(coll.gameObject.name);
    }
}
