using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SideScrollerMovement : MonoBehaviour
{
    public float speed = 5f;
    public bool canMove = true;

    private Rigidbody2D rb;
    private Animator anim;

    private float horizontalInput;

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public float jumpSpeed = 5f;

    private int facingDirection = 1;
    private bool isFacingRight = true;

    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmision;

    AudioSource ziplamaSesi;

    bool balaDegdi;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ziplamaSesi = GetComponent<AudioSource>();
        footEmision = footsteps.emission;
        balaDegdi = false;
        facingDirection = 1;
        isFacingRight = true;
        canMove = true;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        GetInput();
        CheckSurroundings();
        AnimationUpdate();

        if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
        {
            footEmision.rateOverTime = 35;
        }

        else
        {
            footEmision.rateOverTime = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!canMove) return;
        ApplyMovement();
    }

    private void GetInput()
    {
        if (!canMove) return;
        

        horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput > 0.01f && !isFacingRight)
        {
            Flip();
        }

        else if(horizontalInput < -0.01f && isFacingRight)
        {
            Flip();
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

    }

    public void StopPlayer()
    {
        canMove = false;
        rb.velocity = new Vector2(0f, 0f);
    }

    public void ResetPlayer()
    {
        canMove = true;
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        ziplamaSesi.Play();
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        isFacingRight = !isFacingRight;
        facingDirection *= -1;
    }

    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    private void AnimationUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("yVelocity", rb.velocity.y);
        anim.SetBool("isGrounded", isGrounded);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "NextLevel":
                FindObjectOfType<SahneYoneticisi>().NextLevel();
                /*string path = Application.dataPath + "/Sonuc.txt";
                string[] satirlar = File.ReadAllLines(path);
                foreach (string satir in satirlar)
                {
                    Debug.Log(satir.Split(' ')[1]);
                }*/
                break;
            case "Finish1":
                FindObjectOfType<RivalBolum1>().rivalSpeed = 0f;
                GameObject.Find("King").GetComponent<DialogueTrigger>().TriggerDialogue();
                string path = Application.dataPath + "/Sonuc.txt";
                string[] satirlar = File.ReadAllLines(path);
                string oyuncuIsmi = satirlar[0].Split(' ')[0];
                File.WriteAllText(path, oyuncuIsmi + " 1\nRakip 1");
                
                break;
            case "Finish2":
                GetComponent<PlayerKazma>().enabled = false;
                GameObject.Find("King").GetComponent<DialogueTrigger>().TriggerDialogue();
                FindObjectOfType<LevelIkiSayac>().geriSayim = false;
                path = Application.dataPath + "/Sonuc.txt";
                satirlar = File.ReadAllLines(path);
                oyuncuIsmi = satirlar[0].Split(' ')[0];
                File.WriteAllText(path, oyuncuIsmi + " 2\nRakip 2");
                break;
            case "PatlayiciUyari":
                other.GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "PatlayiciBilgi":
                other.GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            case "Level3Dialog":
                other.GetComponent<DialogueTrigger>().TriggerDialogue();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Level3Dialog":
                FindObjectOfType<Level3>().ShowInfo();
                StopPlayer();
                break;
            default:
                break;
        }
    }

    public void SetPlayerSpeed()
    {
        speed = 15f;
        Debug.Log("oyuncu hızı arttı");
    }

    public void SetPlayerJumpSpeed()
    {
        jumpSpeed = 20f;
        Debug.Log("Zıplama gücü arttı!");
    }

    public void DecreaseSpeed()
    {
        speed = 3f;
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.CompareTag("Bal") && !balaDegdi)
        {
            DecreaseSpeed();
            balaDegdi = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
