using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess : MonoBehaviour
{
    bool wasTalked = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !wasTalked)
        {
            GetComponent<DialogueTrigger>().TriggerDialogue();
            wasTalked = true;
        }
    }
}
