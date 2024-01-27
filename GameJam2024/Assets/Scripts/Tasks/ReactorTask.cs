using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactorTask : MonoBehaviour
{
    private string correctCode;
    [SerializeField] private string correctAdminCode;

    [SerializeField] private GameObject img1;
    [SerializeField] private GameObject img2;
    [SerializeField] private GameObject img3;
    [SerializeField] private GameObject treeView;
    [SerializeField] private GameObject reactor;
    [SerializeField] private GameObject adminCode;

    [SerializeField] private Sprite goodChamber;
    [SerializeField] private Sprite badChamber;

    [SerializeField] private TextMeshProUGUI c1;
    [SerializeField] private TextMeshProUGUI c2;
    [SerializeField] private TextMeshProUGUI c3;

    private CmdController cCont;

    private void Start()
    {
        cCont = gameObject.GetComponent<CmdController>();

        for(int i = 4; i > 0; i--)
        {
            correctCode += Random.Range(0, 10).ToString();

            c1.text += Random.Range(0, 10);
            c2.text += Random.Range(0, 10);
            c3.text += Random.Range(0, 10);
        }

        img1.GetComponent<Image>().sprite = badChamber;
        img2.GetComponent<Image>().sprite = badChamber;
        img3.GetComponent<Image>().sprite = badChamber;

        int slot = Random.Range(1, 4);

        switch(slot)
        {
            case 1:
                c1.text = correctCode;
                img1.GetComponent<Image>().sprite = goodChamber;
                break;
            case 2:
                c2.text = correctCode;
                img2.GetComponent<Image>().sprite = goodChamber;
                break;
            case 3:
                c1.text = correctCode;
                img3.GetComponent<Image>().sprite = goodChamber;
                break;
        }
    }

    public void TaskCmd(string cmd)
    {
        if(cmd == correctCode.ToString() && adminCode.activeInHierarchy == false)
        {
            //Flip success in game controller.
            adminCode.SetActive(true);
            reactor.SetActive(false);
        }
        else if(adminCode.activeInHierarchy == true)
        {
            if(cmd == correctAdminCode)
            {
                treeView.SetActive(true);
                adminCode.SetActive(false);
            }
            else if(cmd.ToLower() == "home")
            {
                cCont.curTask = CmdController.ActiveTask.none;
                cCont.taskActive = false;
                cCont.Command();
                adminCode.SetActive(false);
            }
            else if(cmd.ToLower().StartsWith("open"))
            {
                cCont.curTask = CmdController.ActiveTask.none;
                cCont.taskActive = false;
                cCont.Command();
                adminCode.SetActive(false);
            }
        }
        else
        {
            //Do bad thing.
        }
    }
}
