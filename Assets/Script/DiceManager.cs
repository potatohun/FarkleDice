using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager Instance { get; private set; }
    public Dice[] dice;

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
        for (int i = 0; i < 6; i++)
        {
            // Dice 오브젝트를 찾아서 배열에 할당
            dice[i] = transform.GetChild(i).GetComponent<Dice>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
