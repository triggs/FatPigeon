using UnityEngine;
using System.Collections;

/// <summary>
/// Script that allows the Background Quad to scroll.
/// </summary>
public class ScrollingBackground : MonoBehaviour
{
	// Background scrolling speed, can be overwritten in-engine
	public float speed = 0.5f;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		// Create a Vector2 offset & attach to the renderer to scroll the background.
		Vector2 offset = new Vector2 (Time.time * speed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}

