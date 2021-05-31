using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class YaziDeneme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CreateText();
        //ReadText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateText(string karakterIsmi)
    {
        string path = Application.dataPath + "/Sonuc.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, karakterIsmi + " 0\nRakip 0");
        }

        else
        {
            File.WriteAllText(path, karakterIsmi + " 0\nRakip 0");
        }
    }

    public void ReadText()
    {
        string okunanYazi = File.ReadAllText(Application.dataPath + "/Sonuc.txt");
        Debug.Log("okunanYazi:" + okunanYazi);
    }
}
