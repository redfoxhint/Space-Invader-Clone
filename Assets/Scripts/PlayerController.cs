using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float lerpTime;
    [SerializeField] private float moveSpeed;

    private Vector3 movement;
    private Vector3 input;

    #region Event Setup

    private void OnEnable()
    {
        DirectionManager.OnDirectionChanged += UpdateFacingDirection;
    }

    private void OnDisable()
    {
        DirectionManager.OnDirectionChanged -= UpdateFacingDirection;
    }
    #endregion

    private void Update()
    {
        if(!DirectionManager.instance.isChangingDirection)
        {
            PlayerInput(DirectionManager.instance.currentDirection);
        }
    }

    private void PlayerInput(DirectionManager.Direction dir)
    {
        switch (dir)
        {
            case DirectionManager.Direction.FORWARD:
                input = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                movement = input * moveSpeed * Time.deltaTime;
                transform.position += movement;
                break;

            case DirectionManager.Direction.BACKWARD:
                input = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                movement = input * moveSpeed * Time.deltaTime;
                transform.position -= movement;
                break;

            case DirectionManager.Direction.LEFT:
                input = new Vector3(0f, 0f, Input.GetAxis("Horizontal"));
                movement = input * moveSpeed * Time.deltaTime;
                transform.position += movement;
                break;

            case DirectionManager.Direction.RIGHT:
                input = new Vector3(0f, 0f, Input.GetAxis("Horizontal"));
                movement = input * moveSpeed * Time.deltaTime;
                transform.position -= movement;
                break;
        }
    }

    private void UpdateFacingDirection()
    {
        transform.position = Vector3.zero;
        StartCoroutine(DirectionManager.instance.ChangeFacing(transform, lerpTime));
    }
}
