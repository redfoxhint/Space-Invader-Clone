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
            InputAndConstraints();
        }
    }

    private void InputAndConstraints()
    {
        switch (DirectionManager.instance.currentDirection)
        {
            case DirectionManager.Direction.FORWARD:
                input = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                movement = input * moveSpeed * Time.deltaTime;
                transform.position += movement;

                if(transform.position.x > 5.6f) transform.position = new Vector3(5.6f, 0f, 0f);
                if (transform.position.x < -5.6f) transform.position = new Vector3(-5.6f, 0f, 0f);

                break;

            case DirectionManager.Direction.BACKWARD:
                input = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
                movement = input * moveSpeed * Time.deltaTime;
                transform.position -= movement;

                if (transform.position.x > 5.6f) transform.position = new Vector3(5.6f, 0f, 0f);
                if (transform.position.x < -5.6f) transform.position = new Vector3(-5.6f, 0f, 0f);

                break;

            case DirectionManager.Direction.LEFT:
                input = new Vector3(0f, 0f, Input.GetAxis("Horizontal"));
                movement = input * moveSpeed * Time.deltaTime;
                transform.position += movement;

                if (transform.position.z > 5.6f) transform.position = new Vector3(0f, 0f, 5.6f);
                if (transform.position.z < -5.6f) transform.position = new Vector3(0f, 0f, -5.6f);

                break;

            case DirectionManager.Direction.RIGHT:
                input = new Vector3(0f, 0f, Input.GetAxis("Horizontal"));
                movement = input * moveSpeed * Time.deltaTime;
                transform.position -= movement;

                if (transform.position.z > 5.6f) transform.position = new Vector3(0f, 0f, 5.6f);
                if (transform.position.z < -5.6f) transform.position = new Vector3(0f, 0f, -5.6f);

                break;
        }
    }

    private void UpdateFacingDirection()
    {
        transform.position = Vector3.zero;
        StartCoroutine(DirectionManager.instance.ChangeFacing(transform, lerpTime));
    }
}
