using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameplay : MonoBehaviour
{
    private const int numberOfPlayers = 4;
    [SerializeField] TextMeshProUGUI playerA;
    [SerializeField] TextMeshProUGUI playerB;
    [SerializeField] TextMeshProUGUI playerC;
    [SerializeField] TextMeshProUGUI playerD;
    [Header("Names")]
    [SerializeField] string playerAName;
    [SerializeField] string playerBName;
    [SerializeField] string playerCName;
    [SerializeField] string playerDName;
    private string[] players;
    private const int numberOfRounds = 12;
    private const int quatroRoundsIndex = 8;
    private char[] rounds = new[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'B', 'M', 'Z', 'F'};
    int roundCounter = 1;
    int currentRoundIndex = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerA.SetText(playerAName);
        playerB.SetText(playerBName);
        playerC.SetText(playerCName);
        playerD.SetText(playerDName);
        Debug.Log(rounds[currentRoundIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextRound();
            Debug.Log(rounds[currentRoundIndex]);
            Debug.Log($"round index: {currentRoundIndex}; round counter:{roundCounter}");
        }
    }

    public char NextRound()
    {
//        Переход между первыми восьмью раундами
        if (rounds[currentRoundIndex] < rounds[quatroRoundsIndex])
        {
            currentRoundIndex++;
        }
//        Раунды, которые идут по четыре
        else
        {
            if (roundCounter < numberOfPlayers)
            {
                roundCounter++;
            }
            else if (currentRoundIndex <= numberOfRounds)
            {
                roundCounter = 1;
                currentRoundIndex++;
            }
        }

        return rounds[currentRoundIndex];
    }
}