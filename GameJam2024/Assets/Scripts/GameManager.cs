using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //camera vars
    [SerializeField] private GameObject cameraManager;
    private CinemachineBehavior cb;     //to forve the camera movement type cb.ForceMoniter1 (or 2) to refrece function

    public static Action StartVIM, Yapster, Unstable, SpotIt;
    [SerializeField] private List<int> MalwareList = new List<int>();




    private void Start()
    {
        SetGameState();

        if(cameraManager != null)
        {
            cb = cameraManager.GetComponent<CinemachineBehavior>();
        }
    }

    private void SetGameState()
    {
        switch(gameTime)
        {
            case 0:
                GamePhase = 1;
                StartCoroutine(GameTimer());
                print("PHASE 1");
                StartVIM?.Invoke();
                break;
            case 1.5f:
                SelectMalware(); //malware
                break;
            case 4:
                GamePhase = 2;
                print("PHASE 2");
                //jingle
                break;
            case 4.5f:
                SelectMalware(); //malware
                break;
            case 7.5f:
                GamePhase = 3;
                print("PHASE 3");
                SelectMalware(); //malware
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

    private void SelectMalware()
    {
        int index = UnityEngine.Random.Range(0, MalwareList.Count - 1);

        switch(MalwareList[index])
        {
            case 0:
                Unstable?.Invoke();
                MalwareList.Remove(0);
                break;
            case 1:
                Yapster?.Invoke();
                MalwareList.Remove(1);
                break;
            case 2:
                SpotIt?.Invoke();
                MalwareList.Remove(2);
                break;
        }
    }
}
