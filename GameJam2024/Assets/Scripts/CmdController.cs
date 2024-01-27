using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CmdController : MonoBehaviour
{
    private string prevDir;

    public bool taskActive = false;

    private List<string> commands = new List<string>();

    [SerializeField] private TMP_InputField cmdLn;

    [SerializeField] private GameObject treeView;
    [SerializeField] private GameObject txtView;
    [SerializeField] private GameObject init;
    [SerializeField] private GameObject reactor;

    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private TextMeshProUGUI[] treeFields;

    public enum ActiveTask
    {
        none,
        reactor,
        power,
        doors,
        security,
        connection,
        killcode,
        monster
    }

    public ActiveTask curTask = ActiveTask.none;

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

        if(command == "")
        {
            return;
        }

        if(taskActive == true)
        {
            TaskCommand(command);
            cmdLn.text = "";
            cmdLn.ActivateInputField();
            return;
        }

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

        cmdLn.DeactivateInputField();
        cmdLn.ActivateInputField();
    }

    private void OpenParser(string fileName)
    {
        switch(fileName.ToLower())
        {
            case "reactorcontrol":
                treeView.SetActive(false);
                txtView.SetActive(false);
                reactor.SetActive(true);
                taskActive = true;
                curTask = ActiveTask.reactor;
                return;
        }

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
    
    private void TaskCommand(string command)
    {
        switch(curTask)
        {
            case ActiveTask.none:
                break;
            case ActiveTask.reactor:
                gameObject.GetComponent<ReactorTask>().TaskCmd(command);
                break;
            case ActiveTask.power:

                break;
            case ActiveTask.doors:

                break;
            case ActiveTask.security:

                break;
            case ActiveTask.connection:

                break;
            case ActiveTask.killcode:

                break;
            case ActiveTask.monster:

                break;
        }
    }
}