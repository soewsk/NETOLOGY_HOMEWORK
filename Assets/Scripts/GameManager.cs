using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();
   [SerializeField] private List<Pin> pins = new List<Pin>();
    private int score;
    private int throwCount = 0;
    private int firstThrowPins = 0;
    public TMP_Text _scoreText;
    public TMP_Text _strikeText;
    public TMP_Text _spareText;

    private bool isStrike = false;
    private bool isSpare = false;


    void Start()
    {
        pins.AddRange(FindObjectsByType<Pin>(FindObjectsSortMode.None));
        _scoreText.text = "Score: " + score;
    }

    public void ShowStrike()
    {
        _strikeText.gameObject.SetActive(true);
        StartCoroutine(HideText());
    }
   public void ShowSpare()
    {
        _spareText.gameObject.SetActive(true);
        StartCoroutine(HideText());
    }


    public void CalculateScore()
    {
        int KnockedPins = 0;
        foreach (var pin in pins)
        {
            if (pin.IsKnockedDown && !pin.isCounted)
            {
                KnockedPins++;
            
                pin.isCounted = true;
           
            }
        }
        rolls.Add(KnockedPins);
        score += KnockedPins;
      
        throwCount++;
        if(throwCount == 1)
        {
            firstThrowPins = KnockedPins;
            if(firstThrowPins == 10)
            {
                isStrike = true;
                Debug.Log("Strike");
                ShowStrike();
                throwCount = 0;
                firstThrowPins = 0;
                score += 10;
                Debug.Log(score);
                foreach (var pin in pins)
                {
                    pin.ResetPin();
                }
            }
         

        }
         if(throwCount == 2)
        {
            if(firstThrowPins + KnockedPins == 10)
            {
                isSpare = true;
                Debug.Log("Spare");
                ShowSpare();
           score += 10;
            }
            throwCount = 0;
            firstThrowPins = 0;
            foreach (var pin in pins)
            {
                pin.ResetPin();
            }
        }

        _scoreText.text = "Score: " + score;
        

    }
    
    public IEnumerator HideText()
    {
        yield return new WaitForSeconds(2f);
        _strikeText.gameObject.SetActive(false);
        _spareText.gameObject.SetActive(false);
    }





}
