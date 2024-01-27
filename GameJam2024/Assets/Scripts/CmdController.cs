using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CmdController : MonoBehaviour
{
    private string prevDir;

    private List<string> commands = new List<string>();

    [SerializeField] private TMP_InputField cmdLn;

    [SerializeField] private GameObject treeView;
    [SerializeField] private GameObject txtView;
    [SerializeField] private GameObject init;

    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private TextMeshProUGUI[] treeFields;

    private void Awake()
    {
        commands.Add("open");
        commands.Add("home");
        commands.Add("back");
        commands.Add("killcode");
    }

    public void Command()
    {
        string command = cmdLn.text;

        string[] splitCmd = command.Split(" ");

        if(splitCmd[0].ToLower() == commands[0])
        {
            //Run file opening function.
            OpenParser(splitCmd[1]);
        }
        else if(splitCmd[0].ToLower() == commands[1])
        {
            //Return to the home file.
            OpenParser("FLOPPYA");
        }
        else
        {
            Debug.Log(prevDir);

            if(prevDir == "NOPREVDIR")
            {

            }
            else
            {
                //Go back to the prior directory.
                OpenParser(prevDir);
            }
        }

        cmdLn.text = "";
    }

    private void OpenParser(string fileName)
    {
        string readData = FileReader.ReadFile(fileName);

        string[] splitData = readData.Split(";");

        if(splitData[0].StartsWith("TREE"))
        {
            int index = 1;

            prevDir = splitData[splitData.Length - 1].Split(" ")[1];
            Debug.Log(prevDir);

            foreach(TextMeshProUGUI j in treeFields)
            {
                j.text = "";
            }

            foreach (TextMeshProUGUI i in treeFields)
            {
                if(index == splitData.Length - 1)
                {
                    break;
                }

                i.text = splitData[index];
                index++;
            }

            //Print out the tree.
            treeView.SetActive(true);
            txtView.SetActive(false);
        }
        else if(splitData[0].StartsWith("TXT"))
        {
            txt.text = splitData[1];

            txtView.SetActive(true);
            treeView.SetActive(false);
        }
    }

    private void ReturnHome()
    {

    }

    private void Back()
    {

    }
}
