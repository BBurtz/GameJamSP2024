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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lost()
    {
        BackGround.GetComponent<SpriteRenderer>().sprite = dBackground;
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
    }
}
