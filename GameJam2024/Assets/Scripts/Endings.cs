using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void lost()
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

    }
}
