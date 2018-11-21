using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DirectionManager : MonoBehaviour
{
    #region DirectionManager Singleton

    public static DirectionManager directionManager;

    public static DirectionManager instance
    {
        get
        {
            if (!directionManager)
            {
                directionManager = FindObjectOfType<DirectionManager>();

                if (!directionManager)
                {
                    Debug.LogError("No EventManager found in the scene.");
                }
            }

            return directionManager;
        }
    }

    #endregion

    public enum Direction { LEFT, RIGHT, FORWARD, BACKWARD };
    public Direction currentDirection;

    [SerializeField] private Transform cameraPivot;
    [SerializeField] private Transform player;

    [SerializeField] private Text dirText;

    public bool isChangingDirection;

    [SerializeField] Quaternion currentRotation;

    public delegate void DirectionChange();
    public static event DirectionChange OnDirectionChanged;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        currentDirection = Direction.FORWARD;
        dirText.text = "Current direction: Forward";
        isChangingDirection = false;
    }

    private void Update()
    {
        if (!isChangingDirection)
        {
            if (Input.GetKeyDown(KeyCode.Keypad8) && currentDirection != Direction.FORWARD)
            {
                currentDirection = Direction.FORWARD;
                currentRotation = CalculateRotation(Vector3.zero);
                dirText.text = "Current direction: Forward";
                ChangeDirection();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6) && currentDirection != Direction.RIGHT)
            {
                currentDirection = Direction.RIGHT;
                currentRotation = CalculateRotation(new Vector3(0f, 90f, 0f));
                dirText.text = "Current direction: Right";
                ChangeDirection();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4) && currentDirection != Direction.LEFT)
            {
                currentDirection = Direction.LEFT;
                currentRotation = CalculateRotation(new Vector3(0f, -90f, 0f));
                dirText.text = "Current direction: Left";
                ChangeDirection();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) && currentDirection != Direction.BACKWARD)
            {
                currentDirection = Direction.BACKWARD;
                currentRotation = CalculateRotation(new Vector3(0f, 180f, 0f));
                dirText.text = "Current direction: Backward";
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        if (OnDirectionChanged != null)
        {
            OnDirectionChanged();
        }

        isChangingDirection = true;
    }

    private Quaternion CalculateRotation(Vector3 rotationToConvert)
    {
        Quaternion newRotation = Quaternion.Euler(rotationToConvert);
        return newRotation;
    }

    public IEnumerator ChangeFacing(Transform targetTransform, float time)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = targetTransform.rotation;

        while (elapsedTime < time)
        {
            targetTransform.rotation = Quaternion.Slerp(startRotation, currentRotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Finished rotating");
        isChangingDirection = false;
    }
}
