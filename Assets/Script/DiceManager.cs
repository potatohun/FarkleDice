using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager Instance { get; private set; }
    public Dice[] dice;
    public List<Dice> selectedDice;
    private int score;

    public enum state
    {
        Nothing,
        OneorFive,
        ThreeN,
        FourN,
        FiveN,
        ThreeOne,
        ThreeFour,
        ThreeFive,
        OneToFive,
        TwoToSix,
        OneToSix
    }

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
        dice = new Dice[6];
        selectedDice = new List<Dice>();
        for (int i = 0; i < 6; i++)
        {
            // Dice 오브젝트를 찾아서 배열에 할당
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
        }
        this.score = 0;
    }

    private Dictionary<int, int> farkleDiceScoring = new Dictionary<int, int>()
    {
        {1, 100}, // 주사위 1의 포인트는 100점
        {5, 50},  // 주사위 5의 포인트는 50점
    };

    public int CalculateScore()
    {

        List<int> selectedNum = new List<int>();
        for(int i = 0;i< selectedDice.Count; i++)
        {
            selectedNum.Add(selectedDice[i].GetNumber());
        }
        selectedNum.Sort();
        string str ="";
        for (int i = 0; i < selectedNum.Count; i++)
        {
            str += (selectedNum[i].ToString());
        }

        switch(str){
            case "11111":
                this.score = 4000;
                break;
            case "1111":
                this.score = 2000;
                break;
            case "111":
                this.score = 1000;
                break;
            case "11":
                this.score = 200;
                break;
            case "1":
                this.score = 100;
                break;
            case "55":
                this.score = 100;
                break;
            case "5":
                this.score = 50;
                break;
            case "123456":
                this.score = 1500;
                break;
            case "23456":
                this.score = 750;
                break;
            case "12345":
                this.score = 500;
                break;
            case "22222":
                this.score = 800;
                break;
            case "2222":
                this.score = 400;
                break;
            case "222":
                this.score = 200;
                break;
            case "33333":
                this.score = 1200;
                break;
            case "3333":
                this.score = 600;
                break;
            case "333":
                this.score = 300;
                break;
            case "44444":
                this.score = 1600;
                break;
            case "4444":
                this.score = 800;
                break;
            case "444":
                this.score = 400;
                break;
            case "55555":
                this.score = 2000;
                break;
            case "5555":
                this.score = 1000;
                break;
            case "555":
                this.score = 500;
                break;
            case "66666":
                this.score = 2400;
                break;
            case "6666":
                this.score = 1200;
                break;
            case "666":
                this.score = 600;
                break;

            default:
                this.score = 0;
                break;
        }
        Debug.Log(str);

        return score;
    }

    public void InitDice()
    {
        selectedDice.Clear();
        for(int i =0;i<dice.Length;i++)
        {
            RectTransform rectTransform = dice[i].GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
            //dice[i].Roll();
            dice[i].SetSelected();
        }
    }

    public bool IsSomethingActive()
    {
        bool isSomethingActive = false;
        for (int i = 0;i < dice.Length;i++){
            if (dice[i].gameObject.activeSelf)
            {
                isSomethingActive = true;
            }
        }
        return isSomethingActive;
    }

    public void AllActive()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].gameObject.SetActive(true);
        }
    }

    public void SelectDice(Dice dice)
    {
        selectedDice.Add(dice);
    }
    public void DeselectDice(Dice dice)
    {
        selectedDice.Remove(dice);
    }

    public int GetScore()
    {
        return this.score;
    }

    public void SetScore(int score)
    {
        this.score = score;
    }
}
