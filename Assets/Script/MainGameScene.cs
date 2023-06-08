using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainGameScene : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioclip;
    public Text nameText;
    public Button rollbutton;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        audioSource.PlayOneShot(audioclip);
        for(int i = 0; i < 6; i++)
        {
            DiceManager.Instance.dice[i].Roll();
        }
        rollbutton.gameObject.SetActive(false);
    }
    void Start()
    {
        string playerName = GameManager.Instance.GetPlayerName();
        nameText.text = "Welcome " + playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
