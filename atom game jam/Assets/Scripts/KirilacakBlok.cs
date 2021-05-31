using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirilacakBlok : MonoBehaviour
{
    public void Kir()
    {
        GetComponent<Animator>().SetTrigger("Kir");
    }

    public void YokOl()
    {
        Destroy(this.gameObject);
    }
}
