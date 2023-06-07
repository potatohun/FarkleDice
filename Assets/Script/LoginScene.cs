using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScene : MonoBehaviour
{
    public InputField nameInput;

    public void OnButtonClick()
    {
        string playerName = nameInput.text;
        Debug.Log(playerName);
        GameManager.Instance.SetPlayerName(playerName);
        SceneManager.LoadScene("MainGame");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
