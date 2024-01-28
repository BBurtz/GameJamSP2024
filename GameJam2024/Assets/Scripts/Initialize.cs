using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Initialize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] treeFields;

    private void Awake()
    {
        string readData = FileReader.ReadFile("FLOPPYA");

        string[] splitData = readData.Split(";");

        if (splitData[0].StartsWith("TREE"))
        {
            int index = 1;

            foreach (TextMeshProUGUI i in treeFields)
            {
                if (index == splitData.Length - 1)
                {
                    break;
                }

                i.text = splitData[index];
                index++;
            }
        }
    }
}
