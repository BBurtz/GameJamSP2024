using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CinemachineBehavior : MonoBehaviour
{
    [SerializeField] private InputAction action;
    private bool isFacingRight;
    [SerializeField] private CinemachineVirtualCamera leftCam;
    [SerializeField] private CinemachineVirtualCamera rightCam;

    private void Start()
    {
        action.performed += _ => SwitchCameraPriority();
    }

    private void SwitchCameraPriority()
    {
        if(rightCam.Priority == 0)
        {
            rightCam.Priority = 1;
            leftCam.Priority = 0;
        }
        else
        {
            rightCam.Priority = 0;
            leftCam.Priority = 1;
        }
        isFacingRight = !isFacingRight;
    }

    public void ForceMoniter1()
    {
        rightCam.Priority = 0;
        leftCam.Priority = 1;
    }

    public void ForceMoniter2()
    {
        print("print 2");
        rightCam.Priority = 1;
        leftCam.Priority = 0;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
