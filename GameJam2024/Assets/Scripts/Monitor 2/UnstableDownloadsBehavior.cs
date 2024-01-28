using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnstableDownloadsBehavior : MonoBehaviour
{
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject errorMessage;
    public Slider progressBar;
    private bool increment;

    //fx for button- disables button, starts bar progress
    public void ButtonBehavior()
    {
        playButton.SetActive(false);
        increment = true;
        StartCoroutine(IncrementBar());
        StartCoroutine(PauseIncrement());
        errorMessage.SetActive(false);
        AudioManager.Instance.Play("ClickTask");
    }


    //fx to randomly pause progress- enable button, switch inc bool;
    IEnumerator PauseIncrement()
    {
        yield return new WaitForSeconds(5);
        playButton.SetActive(true);
        increment = false;
        errorMessage.SetActive(true);
        AudioManager.Instance.Play("ErrorTask");
    }

    //coroutine loops to add to progress while increment is true
    IEnumerator IncrementBar()
    {
        while (increment)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSeconds(0.4f);      //5 sescs total
            if (progressBar.value == progressBar.maxValue)
            {
                Destroy(gameObject);
                AudioManager.Instance.Play("CorrectTask");
                GameManager.MalwareDone?.Invoke();
            }
        }
    }
}
