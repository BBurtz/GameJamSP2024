using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VIM_Behavior : MonoBehaviour
{
    [SerializeField] private TMP_Text message;


    public void CloseWindow()
    {
        if(GameManager.GamePhase == 3)
        {
            //FLASH ANIMATION
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
