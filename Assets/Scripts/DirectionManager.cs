using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionManager : MonoBehaviour
{
    public enum Direction { LEFT, RIGHT, FORWARD, BACKWARD };
    public Direction currentDirection;

    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform player;

    [SerializeField] Quaternion currentRotation;

    private void Start()
    {
        currentDirection = Direction.FORWARD;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            currentDirection = Direction.FORWARD;
            currentRotation = CalculateRotation(Vector3.zero);
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            currentDirection = Direction.RIGHT;
            currentRotation = CalculateRotation(new Vector3(0f, 90f, 0f));
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            currentDirection = Direction.LEFT;
            currentRotation = CalculateRotation(new Vector3(0f, -90f, 0f));
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentDirection = Direction.BACKWARD;
            currentRotation = CalculateRotation(new Vector3(0f, 180f, 0f));
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        switch (currentDirection)
        {
            case Direction.LEFT:
                cameraPivot.rotation = currentRotation;
                player.rotation = currentRotation;
                break;
            case Direction.RIGHT:
                cameraPivot.rotation = currentRotation;
                player.rotation = currentRotation;
                break;
            case Direction.FORWARD:
                cameraPivot.rotation = currentRotation;
                player.rotation = currentRotation;
                break;
            case Direction.BACKWARD:
                cameraPivot.rotation = currentRotation;
                player.rotation = currentRotation;
                break;
        }
    }

    private Quaternion CalculateRotation(Vector3 rotationToConvert)
    {
        Quaternion newRotation = Quaternion.Euler(rotationToConvert);
        return newRotation;
    }
}
