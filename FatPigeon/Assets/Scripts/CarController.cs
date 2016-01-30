using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    private bool right; // spawns at right, moves right to left
    private GameController gameController;
    private Vector3 moveDirection;

    public void SetMoveDirection(Vector3 _moveDirection)
    {
        moveDirection = _moveDirection;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection);
    }

    /// <summary>
    /// Collision check
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //print(other.tag);
    }

    /// <summary>
    /// Mirrors the object by the vertical axis.
    /// </summary>
    void HorizontalMirror()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    /// <summary>
    /// Sets the gameobject's start position
    /// </summary>
    /// <param name="newPosition"></param>
    void SetStartPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}

