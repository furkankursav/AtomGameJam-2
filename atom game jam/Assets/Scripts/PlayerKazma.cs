using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKazma : MonoBehaviour
{
    public Transform kazmaCheck;
    public float kazmaRadius;
    public LayerMask whatIsMaden;

    public AudioSource kazmaSesi;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            KazmayaBasla();
        }
    }

    private void KazmayaBasla()
    {
        anim.SetTrigger("Kaz");
    }

    public void CheckMaden()
    {
        Collider2D[] madenler = Physics2D.OverlapCircleAll(kazmaCheck.position, kazmaRadius, whatIsMaden);
        kazmaSesi.Play();
        foreach(Collider2D maden in madenler)
        {
            Destroy(maden.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        if(kazmaCheck != null)
        {
            Gizmos.DrawWireSphere(kazmaCheck.position, kazmaRadius);
        }
    }

}
