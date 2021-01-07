using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        var current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        var fps = (int)current;
        text.text = "FPS: " + fps.ToString();
    }
}
