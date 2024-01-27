using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public Sprite CardFace;
    public Sprite CardBack;
    private Selectable selectable;
    private SpriteRenderer spriteRenderer;
    private Solitare solitare;

    private void Start()
    {
        List<string> deck = Solitare.GenerateDeck();
        solitare = FindObjectOfType<Solitare>();

        int i = 0;
        foreach(string card in deck)
        {
            if (this.name == card)
            {
                CardFace = solitare.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();

    }


    private void Update()
    {
        if(selectable.faceUp == true)
        {
            spriteRenderer.sprite = CardFace;
        }
        else
        {
            spriteRenderer.sprite = CardBack;
        }
    }

    public void newInfo(int card)
    {
        
    }
}
