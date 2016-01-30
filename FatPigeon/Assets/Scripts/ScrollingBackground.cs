using UnityEngine;
using System.Collections;

/// <summary>
/// Script that allows the Background Quad to scroll.
/// </summary>
public class ScrollingBackground : MonoBehaviour
{
    public GameController gameController;

	// Allows an asset to be marked as back, middle or foreground 
	// so the speed can be added for parallax
	public bool isBackground = false;
	public bool isMiddleground = false;
	public bool isForeground = false;

    // Use this for initialization
    void Start ()
	{
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		print (gameController);
    }

    // Update is called once per frame
    void Update ()
	{
        // Create a Vector2 offset & attach to the renderer to scroll the background.
        Vector2 offset = new Vector2 (Time.time * gameController.obstacleMoveSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}

