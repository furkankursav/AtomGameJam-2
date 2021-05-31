using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ScoreDataControl : MonoBehaviour
{
    private void Awake()
    {
        string path = Application.dataPath + "/Sonuc.txt";
        if (File.Exists(path))
        {
            string[] satirlar = File.ReadAllLines(path);
            int oyuncuSkor = int.Parse(satirlar[0].Split(' ')[1]);
            int rakipSkor = int.Parse(satirlar[1].Split(' ')[1]);
            if(oyuncuSkor > rakipSkor)
            {
                SceneManager.LoadScene("OyuncuKazandi");
            }

            else if(oyuncuSkor < rakipSkor)
            {
                SceneManager.LoadScene("Level 3");
            }
            
        }
    }
}
