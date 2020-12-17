using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public static Settings SettingsInstance;

    public string ipConfig;

    [SerializeField] private InputField ipInputField;
    [SerializeField] private Button cameraButton;

    private void Awake()
    {
        if (SettingsInstance != null)
        {
            Destroy(SettingsInstance);
        }
        else
        {
            SettingsInstance = this;
            DontDestroyOnLoad(this);

            cameraButton.onClick.AddListener(LoadControl);
            ipConfig = PlayerPrefs.GetString("ipConfig", "ws://192.168.8.101:9090");
        }
    }

    private void LoadControl()
    {
        SceneManager.LoadScene("Control");
    }

    public void SaveHost()
    {
        var inputText = ipInputField.text;
        ipConfig = "ws://" + inputText + ":9090";
        PlayerPrefs.SetString("ipConfig", ipConfig);
    }
}