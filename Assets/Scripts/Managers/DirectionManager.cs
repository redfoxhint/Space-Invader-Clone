using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DirectionManager : MonoBehaviour
{
    public enum Direction { LEFT, RIGHT, FORWARD, BACKWARD };
    public Direction currentDirection;

    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform player;

    [SerializeField] private Text dirText;

    [SerializeField] Quaternion currentRotation;

    private UnityAction directionChangedListener;

    private void Awake()
    {
        directionChangedListener = new UnityAction(ChangeDirection);
        EventManager.StartListening("ChangeDirection", directionChangedListener);
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        currentDirection = Direction.FORWARD;
        dirText.text = "Current direction: Forward";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            currentDirection = Direction.FORWARD;
            currentRotation = CalculateRotation(Vector3.zero);
            dirText.text = "Current direction: Forward";
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            currentDirection = Direction.RIGHT;
            currentRotation = CalculateRotation(new Vector3(0f, 90f, 0f));
            dirText.text = "Current direction: Right";
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            currentDirection = Direction.LEFT;
            currentRotation = CalculateRotation(new Vector3(0f, -90f, 0f));
            dirText.text = "Current direction: Left";
            ChangeDirection();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentDirection = Direction.BACKWARD;
            currentRotation = CalculateRotation(new Vector3(0f, 180f, 0f));
            dirText.text = "Current direction: Backward";
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        cameraPivot.rotation = currentRotation;
        player.rotation = currentRotation;
        player.transform.position = Vector3.zero;
    }

    private Quaternion CalculateRotation(Vector3 rotationToConvert)
    {
        Quaternion newRotation = Quaternion.Euler(rotationToConvert);
        return newRotation;
    }
}
