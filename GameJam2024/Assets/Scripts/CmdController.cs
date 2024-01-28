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
    [SerializeField] private GameObject power;
    [SerializeField] private GameObject doors;
    [SerializeField] private GameObject cameras;
    [SerializeField] private GameObject treeBkgrnd;
    [SerializeField] private GameObject pngTxt;
    [SerializeField] private GameObject animation;
    [SerializeField] private GameObject txtBkgrnd;

    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private TextMeshProUGUI[] treeFields;

    private GameObject gm;

    public List<string> lockedFiles;

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

        gm = GameObject.Find("GameManager");
    }

    public void ResetCmdLn()
    {
        cmdLn.text = "";
        cmdLn.ActivateInputField();
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
            OpenParser("start");

        }
        else if(splitCmd[0].ToLower() == commands[2])
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
        else
        {
            if(gm.GetComponent<GameManager>().Task4 == true && splitCmd[1].ToLower() == "meaningless")
            {
                //Put killcode ending here.
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
            case "reactor":
                treeView.SetActive(false);
                treeBkgrnd.SetActive(false);
                txtView.SetActive(false);
                txtBkgrnd.SetActive(false);
                reactor.SetActive(true);
                taskActive = true;
                curTask = ActiveTask.reactor;
                return;
            case "generator":
                if(gm.GetComponent<GameManager>().Task1 == true)
                {
                    treeView.SetActive(false);
                    treeBkgrnd.SetActive(false);
                    txtView.SetActive(false);
                    txtBkgrnd.SetActive(false);
                    power.SetActive(true);
                    taskActive = true;
                    curTask = ActiveTask.power;
                }
                return;
            case "lockdown":
                if(gm.GetComponent<GameManager>().Task2 == true)
                {
                    treeView.SetActive(false);
                    treeBkgrnd.SetActive(false);
                    txtView.SetActive(false);
                    txtBkgrnd.SetActive(false);
                    doors.SetActive(true);
                    taskActive = true;
                    curTask = ActiveTask.doors;
                    gameObject.GetComponent<DoorsTask>().StartCodes();
                }
                return;
            case "connection":
                if(gm.GetComponent<GameManager>().Task3 == true)
                treeView.SetActive(false);
                treeBkgrnd.SetActive(false);
                txtView.SetActive(false);
                txtBkgrnd.SetActive(false);
                cameras.SetActive(true);
                taskActive = true;
                curTask = ActiveTask.connection;
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
            treeBkgrnd.SetActive(true);
            txtView.SetActive(false);
            txtBkgrnd.SetActive(false);
            pngTxt.SetActive(false);
            animation.SetActive(false);
        }
        else if(splitData[0].StartsWith("TXT"))
        {
            txt.text = splitData[1];

            prevDir = splitData[splitData.Length - 1].Split(" ")[1];

            txtView.SetActive(true);
            txtBkgrnd.SetActive(true);
            treeView.SetActive(false);
            treeBkgrnd.SetActive(false);
        }
        else if(splitData[0].StartsWith("PNGTXT"))
        {
            txt.text = splitData[1];
            prevDir = splitData[splitData.Length - 1].Split(" ")[1];

            txtView.SetActive(true);
            txtBkgrnd.SetActive(true);
            treeView.SetActive(false);
            treeBkgrnd.SetActive(false);

            switch(fileName.ToLower())
            {
                case "erik2":
                    pngTxt.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().spr1;
                    pngTxt.SetActive(true);
                    break;
                case "newspaper":
                    pngTxt.GetComponent<Image>().sprite = gm.GetComponent<GameManager>().spr2;
                    pngTxt.SetActive(true);
                    break;
                case "r_d_day28":
                    pngTxt.SetActive(false);
                    animation.SetActive(true);
                    break;
            }
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
                gameObject.GetComponent<PowerTask>().RotateTile(command);
                break;
            case ActiveTask.doors:
                gameObject.GetComponent<DoorsTask>().TaskCmd(command);
                break;
            case ActiveTask.security:

                break;
            case ActiveTask.connection:
                gameObject.GetComponent<CameraTask>().TaskCmd(command);
                break;
            case ActiveTask.killcode:

                break;
            case ActiveTask.monster:

                break;
        }
    }
}
