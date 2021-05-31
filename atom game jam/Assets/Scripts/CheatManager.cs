using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour
{
    public bool cheatMode;

    public GameObject commandPanel;
    public Text commandText;
    string yazi;


    private void Start()
    {
        CloseConsole();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            cheatMode = !cheatMode;

            if (cheatMode) OpenConsole();
            else CloseConsole();
        }

        if (cheatMode)
        {
            foreach(char letter in Input.inputString)
            {
                
                if(letter == '\b' && yazi.Length > 0) //silme işlemi
                {
                    yazi = yazi.Substring(0, yazi.Length - 1);
                }

                else if(letter == '\r' || letter == '\n') //entera basma
                {
                    switch (yazi)
                    {
                        case "speed_up":
                            FindObjectOfType<SideScrollerMovement>().SetPlayerSpeed();
                            break;
                        case "jump_up":
                            FindObjectOfType<SideScrollerMovement>().SetPlayerJumpSpeed();
                            break;
                        case "help":
                            FindObjectOfType<MenuManager>().ShowHelp();
                            break;
                        default:
                            //yanlış komut
                            break;
                    }
                    CloseConsole();
                    cheatMode = false;
                }

                else //default durum
                {
                    
                    yazi += letter;

                }
                commandText.text = yazi;
            }
        }
    }

    void OpenConsole()
    {
        commandPanel.SetActive(true);
        FindObjectOfType<SideScrollerMovement>().StopPlayer();
        Time.timeScale = 0f;
    }

    void CloseConsole()
    {
        yazi = "";
        commandPanel.SetActive(false);
        FindObjectOfType<SideScrollerMovement>().ResetPlayer();
        Time.timeScale = 1f;
    }
}
