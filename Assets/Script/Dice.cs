using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dice : MonoBehaviour, IPointerClickHandler
{
    private Animator animator;
    public Sprite[] diceImage;
    private Image image;
    private int number;
    private bool isSelect;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        image = GetComponent<Image>();
        isSelect = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerPress;
        RectTransform rectTransform = clickedObject.GetComponent<RectTransform>();

        if (isSelect)
        {
            isSelect = false;
            Debug.Log(this.number + "º±≈√«ÿ¡¶µ ");
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
            DiceManager.Instance.DeselectDice(clickedObject.GetComponent<Dice>());
        }
        else
        {
            isSelect = true;
            Debug.Log(this.number + "º±≈√µ ");
            rectTransform.localScale = new Vector3(1.5f, 1.5f, 1f);
            DiceManager.Instance.SelectDice(clickedObject.GetComponent<Dice>());
        }

        DiceManager.Instance.CalculateScore();
    }
    public void Roll()
    {
        animator.enabled = true;
    }

    public void SetRandomImage()
    {
        if (diceImage.Length > 0)
        {
            int randomIndex = Random.Range(0, diceImage.Length);
            this.number = randomIndex+1;
            animator.enabled = false;
            image.sprite = diceImage[randomIndex];
        }
    }

    public void SetNumber(int number)
    {
        this.number = number;
    }

    public int GetNumber()
    {
        return number;
    }

    public bool GetSelected()
    {
        return this.isSelect;
    }

    public void SetSelected()
    {
        this.isSelect = false;
    }


}
