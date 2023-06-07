using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainGameScene : MonoBehaviour
{
    public Text nameText;
    // Start is called before the first frame update
    void Start()
    {
        string playerName = GameManager.Instance.GetPlayerName();
        nameText.text = playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
