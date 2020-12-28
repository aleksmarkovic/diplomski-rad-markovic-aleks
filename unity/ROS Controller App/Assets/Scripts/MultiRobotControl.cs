using System;
using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using UnityEngine;

public class MultiRobotControl : MonoBehaviour
{
    [SerializeField] private GameObject[] rosConnector;
    [SerializeField] private GameObject[] robotModel;

    private ImageSubscriber activeRobotCamera;
    private ImageSubscriber inactiveRobotCamera;

    private void Awake()
    {
        activeRobotCamera = rosConnector[0].GetComponent<ImageSubscriber>();
        if (Settings.SettingsInstance.MultiRobot != null && Settings.SettingsInstance.MultiRobot.NumberOfRobots > 1)
        {
             robotModel[1].SetActive(true);
             rosConnector[1].SetActive(true);
             
             inactiveRobotCamera = rosConnector[1].GetComponent<ImageSubscriber>();
             inactiveRobotCamera.enabled = false;
        } 
    }

    public void SwitchRobotCamera()
    {
        activeRobotCamera.enabled = false;
        inactiveRobotCamera.enabled = true;

        var tmp = activeRobotCamera;
        activeRobotCamera = inactiveRobotCamera;
        inactiveRobotCamera = tmp;
    }
}
