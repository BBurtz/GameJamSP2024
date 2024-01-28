using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

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

        //Red alarm flashing animation
        AudioManager.Instance.Play("Alarm");
        Invoke("Explode", 3);
    }

    void Explode()
    {
        AudioManager.Instance.Play(""); //monsters head explodes
        //back to normal lights
        BackGround.GetComponent<SpriteRenderer>().sprite = dBackground; //switch for lights off animation when done
    }

    void WhoIsTheMonster()
    {
        WhoMonster.SetActive(true);
        foreach(AudioSource sound in ambiance)
        {
            sound.Stop();
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
        AudioManager.Instance.Play("Losing");
    }
}
