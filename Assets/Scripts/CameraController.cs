using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Event Setup
    private void OnEnable()
    {
        DirectionManager.OnDirectionChanged += UpdateCameraDirection;
    }

    private void OnDisable()
    {
        DirectionManager.OnDirectionChanged -= UpdateCameraDirection;
    }

    #endregion
    
    [SerializeField] private float lerpTime;

    private void UpdateCameraDirection()
    {
        StartCoroutine(DirectionManager.instance.ChangeFacing(transform, lerpTime));
    }
}
