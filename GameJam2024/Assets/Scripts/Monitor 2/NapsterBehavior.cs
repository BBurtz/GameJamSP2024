using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NapsterBehavior : MonoBehaviour
{
    public Slider progressBar;
    [SerializeField] private GameObject sliderFill;
    [SerializeField] private List<float> yValues = new List<float>();

    private void Start()
    {
        //DETERMINE Y VALUE
        //spawn BAD and button
    }

    public void DownloadFile()
    {
        sliderFill.SetActive(true);
        StartCoroutine(DownloadProgress());
    }

    IEnumerator DownloadProgress()
    {
        print("download");
        sliderFill.SetActive(true);
        while (progressBar.value <= progressBar.maxValue)
        {
            progressBar.value += 0.1f;
            yield return new WaitForSeconds(0.1f);      //5 sescs total
        }

        Destroy(gameObject);
    }
}
