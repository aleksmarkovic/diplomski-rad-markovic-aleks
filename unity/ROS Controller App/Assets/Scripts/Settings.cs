using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private InputField ipInputField;
    [SerializeField]
    private Button cameraButton;
    
    private void Awake()
    {
        cameraButton.onClick.AddListener(LoadCamera);
    } 
    
    private void LoadCamera()
    {        
        SceneManager.LoadScene("Camera");
    }

    public void SaveHost()
    {
        PlayerPrefs.SetString("host", ipInputField.text);
    }
}
