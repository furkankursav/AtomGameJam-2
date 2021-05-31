using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalBolum1 : MonoBehaviour
{
    public float rivalSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    public bool run;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;
    bool isGrounded;

    public Transform wallCheck;
    public float jumpSpeed = 10f;
    bool isTouchingWall;

    public ParticleSystem bal;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        run = false;
        bal.Stop();
    }


    private void Update()
    {
       
        rb.velocity = new Vector2(rivalSpeed, rb.velocity.y);
        

        Debug.Log("isTouchingWall: " + isTouchingWall);
        Debug.Log("isGrounded: " + isGrounded);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, groundRadius, whatIsGround);

        if(isTouchingWall && isGrounded)
        {
            Jump();
        }

        UpdateAnimations();
    }


    void UpdateAnimations()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }
    

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    private void OnDrawGizmos()
    {
        if(groundCheck != null)
        {
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }

        if(wallCheck != null)
        {
            Gizmos.DrawWireSphere(wallCheck.position, groundRadius);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KirilacakBlok"))
        {
            other.gameObject.GetComponent<KirilacakBlok>().Kir();
            GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        
        else if (other.gameObject.CompareTag("BalBaslat"))
        {
            bal.Play();
        }

        else if (other.gameObject.CompareTag("BalBitir"))
        {
            bal.Stop();
        }

        else if (other.gameObject.CompareTag("Finish1"))
        {
            FindObjectOfType<MenuManager>().ShowFailed();
        }
    }
}
