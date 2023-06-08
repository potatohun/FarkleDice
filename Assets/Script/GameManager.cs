using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private string player_name;
    private int turn;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        turn = 1;
    }

    public void SetPlayerName(string player_name)
    {
        this.player_name = player_name;
    }

    public string GetPlayerName()
    {
        return this.player_name;
    }

    public int GetTurn()
    {
        return this.turn;
    }

    public void SetPlusTurn()
    {
        this.turn++;
    }
}
