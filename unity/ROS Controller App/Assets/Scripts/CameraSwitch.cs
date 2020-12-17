using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera overheadCamera;

    private bool cameraChange = false;
    
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (cameraChange)
            {
                ShowOverheadView();
                cameraChange = !cameraChange;
            }
            else
            {
                ShowFirstPersonView();
                cameraChange = !cameraChange;
            }
        }
    }

    // Call this function to disable FPS camera,
    // and enable overhead camera.
    public void ShowOverheadView() 
    {
        firstPersonCamera.enabled = false;
        overheadCamera.enabled = true;
    }
    
    // Call this function to enable FPS camera,
    // and disable overhead camera.
    public void ShowFirstPersonView() 
    {
        firstPersonCamera.enabled = true;
        overheadCamera.enabled = false;
    }
}
