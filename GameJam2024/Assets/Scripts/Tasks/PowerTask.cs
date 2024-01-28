using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTask : MonoBehaviour
{
    public List<float> properRot;
    public List<float> rotations;

    [SerializeField] private GameObject a1;
    [SerializeField] private GameObject b1;
    [SerializeField] private GameObject c1;
    [SerializeField] private GameObject a2;
    [SerializeField] private GameObject b2;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject a3;
    [SerializeField] private GameObject b3;
    [SerializeField] private GameObject c3;

    [SerializeField] private GameObject treeView;
    [SerializeField] private GameObject powerControl;
    [SerializeField] private GameObject treeBkgrnd;

    private CmdController cCont;

    private GameObject gm;

    private void Start()
    {
        cCont = gameObject.GetComponent<CmdController>();
        gm = GameObject.Find("GameManager");

        rotations[0] = 90;
        rotations[1] = 90;
        rotations[2] = 180;
        rotations[3] = 0;
        rotations[4] = 0;
        rotations[5] = 0;
        rotations[6] = 270;
        rotations[7] = 90;
        rotations[8] = 0;
    }

    public void RotateTile(string id)
    {
        if(id.ToLower() == "home")
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            cCont.Command();
            powerControl.SetActive(false);
        }
        else if(id.ToLower().StartsWith("open"))
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            cCont.Command();
            powerControl.SetActive(false);
        }
        else if(id.ToLower().StartsWith("back"))
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            cCont.prevDir = "power";
            cCont.Command();
            powerControl.SetActive(false);
        }

        if(id.Length > 2)
        {
            gameObject.GetComponent<CmdController>().ResetCmdLn();
            return;
        }

        switch(id)
        {
            case "a1":
                a1.transform.Rotate(0, 0, 90);
                rotations[0] += 90;
                break;
            case "b1":
                b1.transform.Rotate(0, 0, 90);
                rotations[1] += 90;
                break;
            case "c1":
                c1.transform.Rotate(0, 0, 90);
                rotations[2] += 90;
                break;
            case "a2":
                a2.transform.Rotate(0, 0, 90);
                rotations[3] += 90;
                break;
            case "b2":
                b2.transform.Rotate(0, 0, 90);
                rotations[4] += 90;
                break;
            case "c2":
                c2.transform.Rotate(0, 0, 90);
                rotations[5] += 90;
                break;
            case "a3":
                a3.transform.Rotate(0, 0, 90);
                rotations[6] += 90;
                break;
            case "b3":
                b3.transform.Rotate(0, 0, 90);
                rotations[7] += 90;
                break;
            case "c3":
                c3.transform.Rotate(0, 0, 90);
                rotations[8] += 90;
                break;
        }

        CheckSolution();
    }

    private void CheckSolution()
    {
        int index = 0;

        foreach(float f in properRot)
        {
            float temp = rotations[index];

            if(temp >= 360f)
            {
                temp = temp % 360f;
            }

            if(index == 1 || index == 4 || index == 7)
            {
                if(temp == 180)
                {
                    temp -= 180;
                }
            }

            if(temp != f)
            {
                return;
            }

            index++;
        }

        //Set task bool to complete.
        gm.GetComponent<GameManager>().Task2 = true;
        cCont.curTask = CmdController.ActiveTask.none;
        cCont.taskActive = false;
        treeView.SetActive(true);
        treeBkgrnd.SetActive(true);
        powerControl.SetActive(false);
        AudioManager.Instance.Play("CorrectTask");
    }
}
