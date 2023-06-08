using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainGameScene : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioclip1;
    public AudioClip audioclip2;
    public Text nameText;
    public Button rollbutton;
    public Button earnbutton;
    public Button stopbutton;

    public Text currentScore;
    public Text saveScore;
    public Text finalScore;
    public Text farkle;
    public Text turn;

    // Start is called before the first frame update
    public void OnRollButtonClick()
    {
        audioSource.PlayOneShot(audioclip1);
        for(int i = 0; i < 6; i++)
        {
            DiceManager.Instance.dice[i].Roll();
        }
        rollbutton.gameObject.SetActive(false);
        earnbutton.gameObject.SetActive(true);
        stopbutton.gameObject.SetActive(false);
        DiceManager.Instance.SetScore(0);
    }

    public void OnStopButtonClick()
    {
        finalScore.text = (Convert.ToInt32(finalScore.text) + Convert.ToInt32(saveScore.text)).ToString();
        saveScore.text = "0";
        DiceManager.Instance.SetScore(0);
        DiceManager.Instance.AllActive();
        audioSource.PlayOneShot(audioclip1);
        DiceManager.Instance.AllRoll();
        rollbutton.gameObject.SetActive(false);
        earnbutton.gameObject.SetActive(true);
        UpdateTurn();
    }

    public void OnEarnButtonClick()
    { 
        if(DiceManager.Instance.CalculateScore() == 0)
        {
            //Farkle!!
            audioSource.PlayOneShot(audioclip1);
            DiceManager.Instance.AllRoll();
            saveScore.text = "0";
            farkle.gameObject.SetActive(true);
            Invoke("HideFarkle", 1f);
            DiceManager.Instance.AllActive();
            UpdateTurn();
            DiceManager.Instance.SetScore(0);
            DiceManager.Instance.InitDice();
            stopbutton.gameObject.SetActive(true);
        }
        else
        {
            
            saveScore.text = (Convert.ToInt32(saveScore.text) + DiceManager.Instance.CalculateScore()).ToString();
            for(int i =0; i< DiceManager.Instance.selectedDice.Count; i++)
            {
                DiceManager.Instance.selectedDice[i].gameObject.SetActive(false);
            }
            if (!DiceManager.Instance.IsSomethingActive())
            {
                audioSource.PlayOneShot(audioclip2);
                DiceManager.Instance.AllActive();
                DiceManager.Instance.AllRoll();
                Debug.Log("전부 다시 활성화!");
                DiceManager.Instance.SetScore(0);
                DiceManager.Instance.InitDice();
                rollbutton.gameObject.SetActive(false);
                stopbutton.gameObject.SetActive(true);
            }
            else
            {
                DiceManager.Instance.SetScore(0);
                DiceManager.Instance.InitDice();
                rollbutton.gameObject.SetActive(true);
                stopbutton.gameObject.SetActive(true);
            }
        }

        
    }
    void Start()
    {
        string playerName = GameManager.Instance.GetPlayerName();
        nameText.text = "Welcome " + playerName;
        turn.text = "Turn " + GameManager.Instance.GetTurn();
    }

    // Update is called once per frame
    void Update()
    {
        currentScore.text = DiceManager.Instance.GetScore().ToString();
    }
    private void HideFarkle()
    {
        farkle.gameObject.SetActive(false);
    }
    private void UpdateTurn()
    {
        GameManager.Instance.SetPlusTurn();
        turn.text = "Turn " + GameManager.Instance.GetTurn();
    }
}
