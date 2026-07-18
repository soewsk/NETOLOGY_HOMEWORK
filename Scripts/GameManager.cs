using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();
    public List<Pin> pins = new List<Pin>();
    private int score;
    private int throwCount = 0;
    private int firstThrowPins = 0;
    public TMP_Text _scoreText;

    private bool isStrike = false;
    private bool isSpare = false;


    void Start()
    {
        pins.AddRange(FindObjectsByType<Pin>(FindObjectsSortMode.None));
        _scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(firstThrowPins == 6)
            {
                isStrike = true;
                Debug.Log("Strike");
                throwCount = 0;
                firstThrowPins = 0;
                score += 10;
                Debug.Log(score);
                
            }
         

        }
         if(throwCount == 2)
        {
            if(firstThrowPins + KnockedPins == 6)
            {
                isSpare = true;
                Debug.Log("Spare");
           score += 10;
            }
            throwCount = 0;
            firstThrowPins = 0;

        }

        _scoreText.text = "Score: " + score;


    }







}
