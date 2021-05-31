using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class OyuncuKazandi : MonoBehaviour
{

    public Animator anim;
    public GameObject finalPanel;

    private void Start()
    {
        finalPanel.SetActive(false);
        
    }

    public void OyundanCikis()
    {
        Application.Quit();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Final");
            other.GetComponent<SideScrollerMovement>().StopPlayer();
            string path = Application.dataPath + "/Sonuc.txt";
            string[] satirlar = File.ReadAllLines(path);
            string isim = satirlar[0].Split(' ')[0];
            File.WriteAllText(path, isim + " 0\nRakip 0");
            finalPanel.SetActive(true);
        }
    }
}
