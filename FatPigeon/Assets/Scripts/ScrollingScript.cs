using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Parallax scrolling movement to be attached to a layer.
/// </summary>
public class ScrollingScript : MonoBehaviour {

	/// <summary>
	/// Scrolling speed
	/// </summary>
	public Vector2 speed = new Vector2(2,2);

	/// <summary>
	/// Movement direction
	/// </summary>
	public Vector2 direction = new Vector2 (-1, 0);

	/// <summary>
	/// Sets if movement should be applied to the camera
	/// </summary>
	public bool isLinkedToCamera = false;


	/// <summary>
	/// The list of children with a renderer
	/// </summary>
	public List<Transform> backgroundPart;


	void Start(){
		
	}


	// Update is called once per frame
	void Update () {

		// Movement of the sprite
		Vector3 movement = new Vector3 (
			                   speed.x * direction.x,
			                   speed.y * direction.y,
			                   0);

		movement *= Time.deltaTime;
		transform.Translate (movement);

		// If set to true, the Camera will be moved instead of the sprite
		if (isLinkedToCamera) {
			Camera.main.transform.Translate (movement);

		}
	}
}

