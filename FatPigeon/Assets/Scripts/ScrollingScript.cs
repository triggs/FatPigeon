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
	/// Sets if the sprite loops and is shown again
	/// </summary>
	public bool isLooping = false;

	/// <summary>
	/// The list of children with a renderer
	/// </summary>
	private List<Transform> backgroundPart;

	/*
	void Start(){
		// For infinitely scrolling sprites
		if (isLooping) {
			// Get all the children of a layer with a renderer
			backgroundPart = new List<Transform>();

			for (int i = 0; i < transform.childCount; i++) {
				Transform child = transform.GetChild(i);

				// Only add the visible children
				if(child.renderer != null){
					backgroundPart.Add(child);
				}
			}

			// Sort by position
			backgroundPart = backgroundPart.OrderBy(
				t => t.position.x
			).ToList();
		}
	}
	*/

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

		/*
		// If set to true, the sprite will loop infinitely
		if(isLooping){
			// Get the first object, the list is ordered from left to right
			Transform firstChild = backgroundPart.FirstOrDefault();

			if (firstChild != null) {
				// Check if the child is partly before the camera
				if (firstChild.position.x < Camera.main.transform.position.x) {
					// If the child is to the left of the camera (outside the FOV)
					// it checks to see if it needs to be recycled
					if (firstChild.renderer.IsVisibleFrom (Camera.main) == false) {
						// Get the last child position
						Transform lastChild = backgroundPart.LastOrDefault ();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);
						//Vector3 lastSize = new Vector3();

						// Set the position of the recycled sprite to be after the the last child
						firstChild.position = new Vector3(
							lastPosition.x + lastSize.x, 
							firstChild.position.y, 
							firstChild.position.z
						);

						backgroundPart.Remove (firstChild);
						backgroundPart.Add (firstChild);

					}
				}
			}
		}*/
	}
}
