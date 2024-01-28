using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Endings : MonoBehaviour
{
    [SerializeField] private float LightsOffTime;

    [SerializeField] private GameObject BackGround;
    [SerializeField] private Sprite nBackground;
    [SerializeField] private Sprite rBackground;
    [SerializeField] private Sprite dBackground;

    [SerializeField] private GameObject ErrorText;
    [SerializeField] private List<GameObject> OtherCanvasItems;

    [SerializeField] private List<GameObject> AllItems;

    [SerializeField] private GameObject WhoMonster;
    [SerializeField] private List<AudioSource> ambiance;

    [SerializeField] private TMP_InputField prompt;
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private List<GameObject> computerScreen;

    bool loss = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void win()
    {
        //enter a killcode (enter here)
        //monitor not interactable ?
        //red alarm flashing ?
        //alarm sounding \/
        //hear monster fucking die \/
        //back to normal lighting ?
        //message pops up saying "who is the monster?" \/
        //Lights go out\/
        //cut Ambient noise \/
        //anwser qusetion
        //lights really go out
        //just message
        //fade to black

        Debug.Log("WIN");

        //Red alarm flashing animation
        loss= false;
        AudioManager.Instance.Play("Alarm");
        Invoke("Explode", 3);
        Invoke("WhoIsTheMonster", 4);
    }

    void Explode()
    {
        AudioManager.Instance.Play("Explosion"); //monsters head explodes
        //back to normal lights
        BackGround.GetComponent<SpriteRenderer>().sprite = dBackground; //switch for lights off animation when done
    }


    /// <summary>
    /// Enables the final question prompt
    /// </summary>
    void WhoIsTheMonster()
    {
        WhoMonster.SetActive(true);

        foreach(GameObject stuff in computerScreen)
        {
            stuff.SetActive(false);
        }

        //Allows for user input when the prompt appears
        //prompt.ActivateInputField();

        foreach (AudioSource sound in ambiance)
        {
            sound.Stop();
        }
        Invoke("ShutOff", 3);
    }

    /// <summary>
    /// Checks what the player said
    /// </summary>
    public void Response()
    {
        WhoMonster.SetActive(true);
        string answer = prompt.text;
        prompt.DeactivateInputField();

        switch(answer.ToLower())
        {
            case "me":
            case "myself":
            case "i am":
            case "shelley":
            case "dr. shelley":
            case "dr shelley":
                Ending();
                break;
            default:
                Error();
                break;
        }
    }

    public void lost()
    {
        BackGround.GetComponent<SpriteRenderer>().sprite = dBackground; //switch for lights off animation when done
        Invoke("Error", 1);
    }

    void Error()
    {
        ErrorText.SetActive(true);
        foreach (GameObject Item in OtherCanvasItems)
        {
            Item.SetActive(false);
        }
        Invoke("Everythingoff", 2);
        Invoke("ReturnHome", 10);
    }

    void Ending()
    {
        foreach (GameObject item in AllItems)
        {
            item.SetActive(false);
        }

        foreach (GameObject Item in OtherCanvasItems)
        {
            Item.SetActive(false);
        }

        //Disables the text
        Invoke("DisableAnswer", 2);
        //Goes to main menu
        Invoke("ShutOff", 4);
        Invoke("ReturnHome", 6);
    }

    /// <summary>
    /// Disables what the player answered
    /// </summary>
    private void DisableAnswer()
    {
        prompt.text = "";
        prompt.gameObject.SetActive(false);
    }

    /// <summary>
    /// Returns the player to the main menu
    /// </summary>
    private void ReturnHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Turns off everything and reenables the loading screen
    /// </summary>
    private void ShutOff()
    {
        foreach (GameObject item in AllItems)
        {
            item.SetActive(false);
        }
        foreach (GameObject Item in OtherCanvasItems)
        {
            Item.SetActive(false);
        }
        Invoke("startOver", 2);
    }

    void startOver()
    {
        SceneManager.LoadScene(0);
    }

    void Everythingoff()
    {
        ErrorText.SetActive(false);
        foreach (GameObject item in AllItems)
        {
            item.SetActive(false);
        }
        //screen goes off so no light is there to see anything
        //play knocking audio
        if (loss)
        {
            AudioManager.Instance.Play("Losing");
        }
        Invoke("startOver", 10);
    }
}
