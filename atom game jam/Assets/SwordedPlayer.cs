using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordedPlayer : MonoBehaviour
{
    public Transform swordCheck;
    public float swordRadius;
    public LayerMask whatIsEnemy;
    private float lastAttackTime = Mathf.NegativeInfinity;
    public float attackDuration;
    public float attackDamage = 10;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= attackDuration + lastAttackTime)
        {
            Saldir();
            lastAttackTime = Time.time;
        }
    }


    void Saldir()
    {
        anim.SetTrigger("Attack");
    }

    public void TriggerAttack()
    {

        Collider2D enemy = Physics2D.OverlapCircle(swordCheck.position, swordRadius, whatIsEnemy);

        if (enemy != null)
        {
            //enemy damage
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(swordCheck.position, swordRadius);
    }
}
