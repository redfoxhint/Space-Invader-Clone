using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float followTime;
    [SerializeField] private float moveSpeed;

    [SerializeField] private DirectionManager dirManager;

    private Vector3 movement;
    private Vector3 input;

    private void Start()
    {
        
    }

    private void Update()
    {
        PlayerInput(dirManager.currentDirection);
    }

    private void PlayerInput(DirectionManager.Direction dir)
    {
        switch(dir)
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
    
}
