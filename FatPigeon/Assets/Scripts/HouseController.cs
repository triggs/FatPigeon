﻿using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {

	private Vector3 moveDirection;

	public void SetMoveDirection(Vector3 _moveDirection)
	{
		moveDirection = _moveDirection;
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(moveDirection);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Car")
		{
		}
	}

	void SetStartPosition(Vector3 newPosition)
	{
		transform.position = newPosition;
	}
}
