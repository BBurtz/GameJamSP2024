using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public int number;

    public bool Spades;
    public bool Daimonds;
    public bool Clubs;
    public bool Hearts;

    public bool CardReveled;

    public void newInfo(int card)
    {
        if(card <= 13)
        {
            Spades = true;
        }
        else if(card <= 26)
        {
            Daimonds = true;
        }
        else if(card <= 39)
        {
            Clubs = true;
        }
        else if(card <= 52)
        {
            Hearts = true;
        }
        number = card % 13;
    }
}
