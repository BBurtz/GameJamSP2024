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

    [SerializeField] private GameObject canvas;
    private Coroutine canvasOn;
    [SerializeField] private GameObject Monitor2;
    private Monitor2Behavior m2b;

    private void Start()
    {
        action.performed += _ => SwitchCameraPriority();
        m2b = Monitor2.GetComponent<Monitor2Behavior>();
    }

    private void SwitchCameraPriority()
    {
        if(rightCam.Priority == 0)
        {
            canvas.SetActive(false);
            if(canvasOn != null)
            {
                StopCoroutine(canvasOn);
            }
            rightCam.Priority = 1;
            leftCam.Priority = 0;
        }
        else
        {
            canvasOn = StartCoroutine(CanvasOn());
            rightCam.Priority = 0;
            leftCam.Priority = 1;
        }
        isFacingRight = !isFacingRight;
    }

    public void ForceMoniter1()
    {
        canvasOn = StartCoroutine(CanvasOn());
        rightCam.Priority = 0;
        leftCam.Priority = 1;
    }

    public void ForceMoniter2()
    {
        canvas.SetActive(false);
        if (canvasOn != null)
        {
            StopCoroutine(canvasOn);
        }
        rightCam.Priority = 1;
        leftCam.Priority = 0;
    }

    private IEnumerator CanvasOn()
    {
        yield return new WaitForSeconds(1f);
        if(!m2b.MalwareIsActive)
        {
            canvas.SetActive(true);
        }
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
