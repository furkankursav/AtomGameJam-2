using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YavasZemin : MonoBehaviour
{

    bool firstTime = true;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && firstTime)
        {
            firstTime = false;
            other.gameObject.GetComponent<SideScrollerMovement>().DecreaseSpeed();
        }
    }
}
