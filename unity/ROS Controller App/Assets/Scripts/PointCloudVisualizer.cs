using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class PointCloudVisualizer : MonoBehaviour
{
    public Material material;
    public bool newMessage;
    public bool  createMap;
    public RosSharp.RosBridgeClient.MessageTypes.Custom.CustomPointCloudMsg customPointCloudMsg;
    public GameObject rosConnector;

    private GameObject octoSpheres;
    private bool mapping;

    private void Start()
    {
        mapping = false;
        octoSpheres = new GameObject("octoSpheres");
    }

    private void Update()
    {
        if (newMessage && mapping)
        {
            newMessage = false;
            Create3DMap();
        }
    }        
    
    private void Create3DMap()
    {
        for (int i = 0; i < customPointCloudMsg.dataPoints.Length; i++)
        {          
            if (customPointCloudMsg.dataPoints[i].z < 0.10f) continue;

            var newPrimitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
           
            newPrimitive.transform.parent = octoSpheres.transform;
            newPrimitive.GetComponent<Renderer>().material = material;

            newPrimitive.transform.localScale = 0.05f * Vector3.one;
            newPrimitive.transform.localPosition = new Vector3(-customPointCloudMsg.dataPoints[i].y,
                customPointCloudMsg.dataPoints[i].z, customPointCloudMsg.dataPoints[i].x);

           // octoDataPoints.Add(newPrimitive);
        }
    }

    public void TurnOnOff3DMapping()
    {
        mapping = !mapping;

        if (!mapping)
            Destroy(octoSpheres);
        else
            octoSpheres = new GameObject("octoSpheres");
    }
}
