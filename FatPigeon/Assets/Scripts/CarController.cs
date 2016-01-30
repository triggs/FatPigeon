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

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.tag);
    }

    void HorizontalMirrorAndShiftUp()
    {
        print("Let's mirror.");
        transform.Rotate(new Vector3(0, 180, 0));
        var newPosition = new Vector3(20, -1, 0);
        transform.position = newPosition;
    }
}

