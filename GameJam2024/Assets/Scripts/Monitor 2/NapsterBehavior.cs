using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NapsterBehavior : MonoBehaviour
{
    public Slider progressBar;
    [SerializeField] private GameObject sliderFill;
    [SerializeField] private GameObject virus;
    [SerializeField] private List<float> yValues = new List<float>();

    private void Start()
    {
        MoveVirus();
    }

    private void MoveVirus()
    {
        //pick y value
        int targetY = Random.Range(0, yValues.Count - 1);

        //move to y value
        virus.GetComponent<RectTransform>().anchoredPosition = new Vector2(1.3f, yValues[targetY]);
    }

    public void DownloadFile()
    {
        sliderFill.SetActive(true);
        StartCoroutine(DownloadProgress());
    }

    IEnumerator DownloadProgress()
    {
        sliderFill.SetActive(true);
        while (progressBar.value <= progressBar.maxValue)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSeconds(0.1f);      //5 sescs total
            if(progressBar.value == progressBar.maxValue)
            {
                Destroy(gameObject);
            }
        }
    }
}
