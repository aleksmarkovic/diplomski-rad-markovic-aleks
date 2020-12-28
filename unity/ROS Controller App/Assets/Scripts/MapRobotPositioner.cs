using System.Collections;
using System.Collections.Generic;
using RosSharp;
using UnityEngine;

public class MapRobotPositioner : MonoBehaviour
{
    private const int UNITY_POSITION_MULTIPLIER = 20;
    public void SetPosition(Vector3 position)
    {
      //  transform.localPosition = new Vector3(position.z * UNITY_POSITION_MULTIPLIER,-position.x * UNITY_POSITION_MULTIPLIER,position.y * UNITY_POSITION_MULTIPLIER) ;
    }
}
