using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreDusur : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Sonuc.txt";
        string[] satirlar = File.ReadAllLines(path);
        string oyuncuIsmi = satirlar[0].Split(' ')[0];
        File.WriteAllText(path, oyuncuIsmi + " 0\nRakip 2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
