using UnityEngine;
using System.Collections;

/// <summary>
/// Script that allows the Background Quad to scroll.
/// </summary>
public class ScrollingBackground : MonoBehaviour
{
    public GameController gameController;

    // Use this for initialization
    void Start ()
	{
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update ()
	{
        // Create a Vector2 offset & attach to the renderer to scroll the background.
        Vector2 offset = new Vector2 (Time.time * gameController.obstacleMoveSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}

