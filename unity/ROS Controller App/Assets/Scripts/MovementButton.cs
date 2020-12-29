using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using UnityEngine;
using UnityEngine.UI;

public class MovementButton : MonoBehaviour
{
    [SerializeField] private TwistPublisherStatic twistPublisherStatic;
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
       // button.onClick.AddListener(ButtonAction);
    }

    public void ButtonAction()
    {
        Debug.Log(gameObject.name);
        switch (gameObject.name)
        {
            case "Up":
                button.GetComponentInChildren<Text>().text = gameObject.name;
                twistPublisherStatic.LinearClickUp();
                button.GetComponentInChildren<Text>().text = "gameObject.name";

                break;
            case "Down":
                twistPublisherStatic.LinearClickDown();
                break;
            case "Right":
                twistPublisherStatic.AngularClickRight();
                break;
            case "Left":
                twistPublisherStatic.AngularClickLeft();
                break;
        }
    }
}
