using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Task Checks")]
    public bool Task1;
    public bool Task2;
    public bool Task3;
    public bool Task4;
    public bool Task5;
    public bool Task6;

    [Header("Timer Variables")]
    public static int GamePhase;
    [SerializeField] private float gameTime;

    private void Start()
    {
        SetGameState();
    }

    private void SetGameState()
    {
        switch(gameTime)
        {
            case 0:
                GamePhase = 1;
                StartCoroutine(GameTimer());
                print("PHASE 1");
                //start VIM
                break;
            case 4:
                GamePhase = 2;
                print("PHASE 2");
                //jingle
                break;
            case 7.5f:
                GamePhase = 3;
                print("PHASE 3");
                break;
            case 10:
                //game ends
                break;
        }
    }

    IEnumerator GameTimer()
    {
        for( int i = 0; i <= 19; i++)
        {
            yield return new WaitForSeconds(30);

            gameTime += 0.5f;
            SetGameState();
        }
    }

}
