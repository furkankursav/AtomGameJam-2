using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject failedPanel;
    public GameObject characterInputPanel;

    public InputField inputField;

    public void ShowHelp()
    {
        Time.timeScale = 0f;
        helpPanel.SetActive(true);
    }

    void HideHelp()
    {
        helpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowFailed()
    {
        failedPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideFailed()
    {
        failedPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && helpPanel.activeInHierarchy)
        {
            HideHelp();
        }
    }

    public void ShowCharacterInput()
    {
        characterInputPanel.SetActive(true);
    }

    public void HideCharacterInput()
    {
        characterInputPanel.SetActive(false);
    }

    public void PlayButton()
    {
        string girilenIsim = inputField.textComponent.text;
        if(girilenIsim != "")
        {
            FindObjectOfType<YaziDeneme>().CreateText(girilenIsim);
            Debug.Log("GirilenIsim: " + girilenIsim);
            FindObjectOfType<SahneYoneticisi>().NextLevel();
        }

    }
}
    
