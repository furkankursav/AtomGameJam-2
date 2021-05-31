using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIkiSayac : MonoBehaviour
{
    public float sure = 100f;
    private float kalanSure;
    public bool geriSayim;
    bool bittiMi;
    public GameObject zamanDolduPanel;

    private void Start()
    {
        kalanSure = sure;
        bittiMi = false;
        geriSayim = true;
        zamanDolduPanel.SetActive(false);
    }

    private void Update()
    {
        if (geriSayim)
        {
            kalanSure -= Time.deltaTime;
            if (kalanSure <= 0f && !bittiMi)
            {
                bittiMi = true;
                ZamanDoldu();
            }
        }
        
    }

    void ZamanDoldu()
    {
        zamanDolduPanel.SetActive(true);   
        FindObjectOfType<SideScrollerMovement>().canMove = false;
        geriSayim = false;
    }

    


}
