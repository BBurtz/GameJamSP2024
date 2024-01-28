using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraTask : MonoBehaviour
{
    private CmdController cCont;
    private GameManager GM;
    
    private List<int> order = new List<int>() { 0, 1, 2, 3 };
    private List<bool> Cams = new List<bool>() { false, false, false, true };
    public List<Sprite> pictures = new List<Sprite>();
    public List<int> Codes = new List<int>();

    public Image Camera;
    public TextMeshProUGUI CodeBox;

    [SerializeField] private GameObject Tree;
    [SerializeField] private GameObject Admin;
    [SerializeField] private GameObject CamTask;
    [SerializeField] private GameObject treeBkgrnd;

    [SerializeField] private string correctCode = "1818";

    // Start is called before the first frame update
    void Start()
    {
        cCont = gameObject.GetComponent<CmdController>();
        Shuffle(order);
        GM = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        Camera.sprite = pictures[order[0]];
        CodeBox.text = Codes[order[0]].ToString();
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskCmd(string cmd)
    {

        if (cmd.ToLower() == "home")
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            CamTask.SetActive(false);
            Admin.SetActive(false);
            cCont.Command();
        }
        else if (cmd.ToLower().StartsWith("open"))
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            CamTask.SetActive(false);
            Admin.SetActive(false);
            cCont.Command();
        }
        else if (cmd.ToLower().StartsWith("switch"))
        {
            string[] temp = cmd.Split(" ");
            if (temp[1] == "1")
            {
                Camera.sprite = pictures[order[0]];
                CodeBox.text = Codes[order[0]].ToString();
            }
            else if (temp[1] == "2")
            {
                Camera.sprite = pictures[order[1]];
                CodeBox.text = Codes[order[1]].ToString();
            }
            else if (temp[1] == "3")
            {
                Camera.sprite = pictures[order[2]];
                CodeBox.text = Codes[order[2]].ToString();
            }
            else if (temp[1] == "4")
            {
                Camera.sprite = pictures[order[3]];
                CodeBox.text = Codes[order[3]].ToString();
            }
        }
        else if (cmd.ToLower().StartsWith("submit"))
        {
            string[] temp = cmd.Split(" ");
            if (temp[1] == Codes[3].ToString())
            {
                CamTask.SetActive(false);
                Admin.SetActive(true);

            }
        }
        else if(cmd.ToLower() == correctCode && Admin.activeInHierarchy)
        {
            GM.Task4 = true;
            Tree.SetActive(true);
            treeBkgrnd.SetActive(true);
            Admin.SetActive(false);
        }
    }
}
