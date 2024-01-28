using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorsTask : MonoBehaviour
{
    private int correctCodes;
    private int wrongCodes;

    [SerializeField] private TMP_InputField cmdLn;

    public TextMeshProUGUI[] codeSlots;

    private Coroutine doorCodes;

    private CmdController cCont;

    private void Start()
    {
        cCont = gameObject.GetComponent<CmdController>();
    }

    private void Update()
    {
        if(correctCodes == 10)
        {
            //Do task completion stuff.
        }

        if(wrongCodes == 3)
        {
            //Force close task.
            ForceExit();

        }
    }

    public void StartCodes()
    {
        for(int i = 0; i < 2; i++)
        {
            codeSlots[0].text += Random.Range(0, 10);
        }

        doorCodes = StartCoroutine(DoorCodes());
    }

    private IEnumerator DoorCodes()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(2f);

            //Start from beginning moving each code forward one slot.
            //If there is a code in the final slot when this happens, add one to wrongCodes.
            //Remove codes that are guessed from the list and skip null entries.
            for (int i = 9; i >= 0; i--)
            {
                if (codeSlots[i].text == "")
                {

                }
                else if (codeSlots[i].text != "" && i == 9)
                {
                    wrongCodes++;
                    codeSlots[i].text = "";
                }
                else
                {
                    string temp = codeSlots[i].text;
                    codeSlots[i + 1].text = temp;
                    codeSlots[i].text = "";

                    if (i == 0)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            codeSlots[i].text += Random.Range(0, 10);
                        }
                    }
                }
            }
        }
    }

    public void StopDoorCodes()
    {
        StopCoroutine(doorCodes);

        wrongCodes = 0;
        correctCodes = 0;

        foreach (TextMeshProUGUI t in codeSlots)
        {
            t.text = "";
        }
    }

    private void ForceExit()
    {
        StopDoorCodes();
        cmdLn.text = "open FLOPPYA";
    }

    public void TaskCmd(string cmd)
    {
        int index = 0;

        if (cmd.ToLower() == "home")
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            cCont.Command();
        }
        else if (cmd.ToLower().StartsWith("open"))
        {
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            cCont.Command();
        }
        else
        {
            foreach (TextMeshProUGUI t in codeSlots)
            {
                if (t.text == cmd)
                {
                    codeSlots[index].text = "";
                    correctCodes++;
                }

                index++;
            }
        }
    }
}
