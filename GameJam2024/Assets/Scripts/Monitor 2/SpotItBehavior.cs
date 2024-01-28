using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotItBehavior : MonoBehaviour
{
    [SerializeField] private GameObject click;

    [SerializeField] private GameObject Image1;
    [SerializeField] private GameObject Image2;
    [SerializeField] private GameObject Image3;
    [SerializeField] private GameObject Image4;

    [SerializeField] private GameObject computer;
    [SerializeField] private GameObject clipBoard;
    [SerializeField] private GameObject package;

    private int itsSpotted;

    //opens the Ispy page
    public void Click()
    {
        click.SetActive(false);
        AudioManager.Instance.Play("ClickTask");
    }

    public void Spotted()
    {
        itsSpotted++;
        AudioManager.Instance.Play("ClickTask");
        ClearImage();
    }

    private void ClearImage()
    {
        switch(itsSpotted)
        {
            case 1:
                Image1.SetActive(false);
                computer.SetActive(false);
                break;
            case 2:
                Image2.SetActive(false);
                clipBoard.SetActive(false);
                break;
            case 3:
                Image3.SetActive(false);
                package.SetActive(false);
                break;
            case 5:
                Destroy(gameObject);
                AudioManager.Instance.Play("CorrectTask");
                break;

        }
    }
}
