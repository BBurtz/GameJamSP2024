using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VIM_Behavior : MonoBehaviour
{
    [SerializeField] private TMP_Text message;


    public void CloseWindow()
    {
        Destroy(gameObject);
    }
}
