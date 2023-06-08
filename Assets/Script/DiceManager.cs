using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager Instance { get; private set; }
    public Dice[] dice;
    public List<Dice> selectedDice;

    public enum state
    {
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
            // Dice ������Ʈ�� ã�Ƽ� �迭�� �Ҵ�
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
        }
    }

    private Dictionary<int, int> farkleDiceScoring = new Dictionary<int, int>()
    {
        {1, 100}, // �ֻ��� 1�� ����Ʈ�� 100��
        {5, 50},  // �ֻ��� 5�� ����Ʈ�� 50��
    };

    public int CalculateScore()
    {
        int score = 0;
        Dictionary<int, int> selectedDiceCounts = new Dictionary<int, int>();

        // ���õ� �ֻ����� �� ���� ������ ī��Ʈ
        foreach (Dice dice in selectedDice)
        {
            int faceValue = dice.GetNumber();
            if (selectedDiceCounts.ContainsKey(faceValue))
            {
                selectedDiceCounts[faceValue]++;
            }
            else
            {
                selectedDiceCounts.Add(faceValue, 1);
            }
        }

        // Farkle Dice ������ ���� ���� ���
        foreach (var kvp in selectedDiceCounts)
        {
            int faceValue = kvp.Key;
            int count = kvp.Value;

            if (farkleDiceScoring.ContainsKey(faceValue))
            {
                // �ֻ��� ���� Farkle Dice ������ ���ԵǸ� �ش� ������ ����Ͽ� ����
                int faceScore = farkleDiceScoring[faceValue];
                score += faceScore * count;
            }
        }

        return score;
    }

    public void InitDice()
    {
        selectedDice.Clear();
        for(int i =0;i<dice.Length;i++)
        {
            RectTransform rectTransform = dice[i].GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
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
}
