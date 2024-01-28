using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuCmdLn : MonoBehaviour
{
    private List<string> commands = new List<string>();

    [SerializeField] private TMP_InputField cmdLn;

    [SerializeField] private GameObject invalid;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject mainMenu;

    [SerializeField] private AudioClip error;

    private void Awake()
    {
        commands.Add("start");
        commands.Add("settings");
        commands.Add("credits");
        commands.Add("quit");
        commands.Add("back");
    }

    private void Start()
    {
        cmdLn.ActivateInputField();
    }

    public void Command()
    {
        string command = cmdLn.text;

        if(command == "")
        {
            return;
        }

        if(command.ToLower().StartsWith("start"))
        {
            //Load main scene.
            SceneManager.LoadScene("MainScene");
        }
        else if (command.ToLower().StartsWith("setting"))
        {
            //Open settings
            //setting.SetActive(true);
            credits.SetActive(false);
            mainMenu.SetActive(false);
        }
        else if(command.ToLower().StartsWith("credit"))
        {
            //Open credits.
            credits.SetActive(true);
            mainMenu.SetActive(false);
            //settings.SetActive(false);
        }
        else if(command.ToLower().StartsWith("quit"))
        {
            Application.Quit();
        }
        else if(command.ToLower().StartsWith("back"))
        {
            mainMenu.SetActive(true);
            credits.SetActive(false);
            //settings.SetActive(false);
        }
        else
        {
            StartCoroutine(Error());
        }

        cmdLn.text = "";
        cmdLn.ActivateInputField();
    }

    private IEnumerator Error()
    {
        invalid.SetActive(true);

        AudioSource.PlayClipAtPoint(error, Vector2.zero, 200f);

        yield return new WaitForSeconds(0.5f);

        invalid.SetActive(false);
    }
}
