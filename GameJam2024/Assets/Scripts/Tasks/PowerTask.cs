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

    private CmdController cCont;

    private void Start()
    {
        cCont = gameObject.GetComponent<CmdController>();

        rotations[0] = a1.transform.rotation.z;
        rotations[1] = b1.transform.rotation.z;
        rotations[2] = c1.transform.rotation.z;
        rotations[3] = a2.transform.rotation.z;
        rotations[4] = b2.transform.rotation.z;
        rotations[5] = c2.transform.rotation.z;
        rotations[6] = a3.transform.rotation.z;
        rotations[7] = b3.transform.rotation.z;
        rotations[8] = c3.transform.rotation.z;

        foreach(float f in rotations)
        {
            if(f >= 360)
            {
                rotations[rotations.IndexOf(f)] = f % 360f;
            }

            Debug.Log(rotations[rotations.IndexOf(f)]);
        }
    }

    public void RotateTile(string id)
    {
        if(id.Length > 2)
        {
            gameObject.GetComponent<CmdController>().ResetCmdLn();
            return;
        }

        switch(id)
        {
            case "a1":
                a1.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[0] = a1.transform.rotation.z;
                break;
            case "b1":
                b1.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[1] = b1.transform.rotation.z;
                break;
            case "c1":
                c1.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[2] = c1.transform.rotation.z;
                break;
            case "a2":
                a2.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[3] = a2.transform.rotation.z;
                break;
            case "b2":
                b2.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[4] = b2.transform.rotation.z;
                break;
            case "c2":
                c2.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[5] = c2.transform.rotation.z;
                break;
            case "a3":
                a3.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[6] = a3.transform.rotation.z;
                break;
            case "b3":
                b3.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[7] = b3.transform.rotation.z;
                break;
            case "c3":
                c3.transform.rotation = new Quaternion(0, 0, transform.rotation.z + 90f, 0);
                rotations[8] = c3.transform.rotation.z;
                break;
        }

        CheckSolution();
    }

    private void CheckSolution()
    {
        int correctIndex = 0;

        foreach(float f in rotations)
        {
            if(rotations.IndexOf(f) == 1 || rotations.IndexOf(f) == 4 || rotations.IndexOf(f) == 7)
            {
                float temp = f;

                temp -= 180;

                if(temp == 0)
                {
                    correctIndex++;
                }
            }
            else
            {
                if(f == properRot[rotations.IndexOf(f)])
                {
                    correctIndex++;
                }
            }
        }

        if(correctIndex == 9)
        {
            //Set task bool to complete.
            cCont.curTask = CmdController.ActiveTask.none;
            cCont.taskActive = false;
            treeView.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
