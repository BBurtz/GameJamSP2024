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

    public static Action StartVIM, Yapster, Unstable, SpotIt, MalwareDone;
    [SerializeField] private List<int> MalwareList = new List<int>();

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;

    [SerializeField] private GameObject radioNeedle;
    private Animator radioAnim;
    [SerializeField] private GameObject AlarmGo;
    private bool alarmOn;
    [SerializeField] private GameObject loadingScreen;


    private void Start()
    {
        StartCoroutine(Preshow());

        radioAnim = radioNeedle.GetComponent<Animator>();
    }

    IEnumerator Preshow()
    {
        yield return new WaitForSeconds(1);
        cb = cameraManager.GetComponent<CinemachineBehavior>();
        cb.ForceMoniter2();
        yield return new WaitForSeconds(2);
        AudioManager.Instance.Play("Podcast1");
        yield return new WaitForSeconds(28);
        StartCoroutine(FirstPodcast());
        StartCoroutine(AlarmAnim());
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
                StartVIM?.Invoke();
                loadingScreen.SetActive(false);
                break;
            case 1.5f:
                SelectMalware(); //malware
                break;
            case 4:
                GamePhase = 2;
                print("PHASE 2");
                StartCoroutine(PaLine());
                break;
            case 4.5f:
                SelectMalware(); //malware
                StartCoroutine(SecondPodcast());
                break;
            case 7.5f:
                GamePhase = 3;
                print("PHASE 3");
                SelectMalware(); //malware
                StartCoroutine(ThirdPodcast());
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
    IEnumerator FirstPodcast()
    {
        yield return new WaitForSeconds(12);
        //radio on
        radioAnim.SetBool("RadioMove", true);

        yield return new WaitForSeconds(8);
        //radio off
        radioAnim.SetBool("RadioMove", false);
    }
    IEnumerator SecondPodcast()
    {
        AudioManager.Instance.Play("Podcast2");
        yield return new WaitForSeconds(30);
        //radio on
        radioAnim.SetBool("RadioMove", true);

        yield return new WaitForSeconds(10);
        //radio off
        radioAnim.SetBool("RadioMove", false);

    }
    IEnumerator ThirdPodcast()
    {
        yield return new WaitForSeconds(9);
        AudioManager.Instance.Play("Podcast3");
        yield return new WaitForSeconds(21);
        //radio on
        radioAnim.SetBool("RadioMove", true);

        yield return new WaitForSeconds(14);
        //radio off
        radioAnim.SetBool("RadioMove", false);

    }
    IEnumerator PaLine()
    {
        AudioManager.Instance.Play("BeepPA");
        yield return new WaitForSeconds(1);
        AudioManager.Instance.Play("BiotechPA");
        yield return new WaitForSeconds(17);
        AudioManager.Instance.Play("NuMedJingle");
    }

    IEnumerator AlarmAnim()
    {
        alarmOn = true;
        StartCoroutine(CheckFirstTask());

        while (alarmOn)
        {
            AlarmGo.SetActive(true);
            yield return new WaitForSeconds(1);
            AlarmGo.SetActive(false);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CheckFirstTask()
    {
        while(Task1 == false)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1);
        alarmOn = false;
    }
}
