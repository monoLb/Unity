using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuPanel : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        startButton=GameObject.Find("StartButton").GetComponent<Button>();
        quitButton=GameObject.Find("QuitButton").GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Cainos/Pixel Art Top Down - Basic/Scene/SC Demo");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
