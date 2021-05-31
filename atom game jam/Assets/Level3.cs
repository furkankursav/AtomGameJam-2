using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : MonoBehaviour
{

    public GameObject infoPanel;

    private void Start()
    {
        infoPanel.SetActive(false);
        Invoke("DialogBaslat", 0.3f);
    }

    public void DialogBaslat() 
    {
        GameObject.Find("Princess").GetComponent<DialogueTrigger>().TriggerDialogue();

    }

    public void ShowInfo()
    {
        infoPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
