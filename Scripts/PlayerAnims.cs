using UnityEngine;
using System.Collections;

public class PlayerAnims : MonoBehaviour
{
    private Animator anim;
    public Transform groundCheck;
    public LayerMask groundMask;
    public bool isGrounded;
    public Camera playerCamera;
    public Transform Katana;
    private AudioSource audioSource;
    public AudioClip hitSound;

    public bool isMoving;
    public bool isAttacking = false;
    public bool isWalking = false;
    public bool isRunning = false;
    private bool isJumping = false;
    public int F;

    public int c = 0;


    private string[] Attacks = { "attack1", "attack4"};

    public int countDamage { get; set; }

    private float culdown;


    void Start()
    {
        anim = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (PauseGame.instance != null && !PauseGame.instance.IsPaused())
        {
            AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

            isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Walk", true);
                isWalking = true;
                isMoving = true;
                playerCamera.transform.localPosition = new Vector3(0.358f, -0.8f, -0.4f);

            }
            else
            {
                anim.SetBool("Walk", false);
                isWalking = false;
                isMoving = false;
                playerCamera.transform.localPosition = new Vector3(0.358f, -0.8f, -0.5f);
            }

            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Run", true);
                isRunning = true;
                isWalking = false;
                anim.SetBool("Walk", false);
                isMoving = true;
                Katana.transform.localPosition = new Vector3(-0.032f, 0.012f, -0.002f);
                Katana.transform.localRotation = Quaternion.Euler(-160.551f, -140.026f, -183.405f);
                playerCamera.transform.localPosition = new Vector3(0.358f, -0.8f, -0.4f);

            }
            else
            {
                Katana.transform.localRotation = Quaternion.Euler(-49.551f, -140.026f, -83.405f);
                Katana.transform.localPosition = new Vector3(-0.011f, -0.018f, 0.009f);


                anim.SetBool("Run", false);
                isRunning = false;

            }
            ////////////////////////////////////////////////////


            AnimationEventOccurred();


            if (isGrounded && Input.GetKey(KeyCode.Space) && !isMoving)
            {
                anim.SetBool("JumpIdle", true);
                isJumping = true;
            }
            else
            {
                anim.SetBool("JumpIdle", false);
                isJumping = false;
            }

            if (isGrounded && Input.GetKey(KeyCode.Space) && isMoving)
            {
                anim.SetBool("JumpSprint", true);
                isJumping = true;
            }

            else
            {
                anim.SetBool("JumpSprint", false);
                isJumping = false;
            }

            if (!currentState.IsName(Attacks[0]) && !currentState.IsName(Attacks[1]))
            {

                countDamage = 1;
            }



            if (!isRunning && !isJumping)
            {

                if (Input.GetMouseButtonDown(0))
                {

                    if (!currentState.IsName(Attacks[0]) && !currentState.IsName(Attacks[1]))
                    {
                        audioSource.PlayOneShot(hitSound);
                        countDamage = 0;

                        F = Random.Range(0, 2);
                        anim.Play(Attacks[F]);

                    }


                }
            }


            if (isAttacking)
            {
                playerCamera.nearClipPlane = 0.5f;
            }
            else
            {
                playerCamera.nearClipPlane = 0.1f;
            }
        }

    }



    public void ChangeCountDamage(int newCount)
    {
        countDamage = newCount;
    }

    public void AnimationEventOccurred()
    {
        AnimatorStateInfo currentState = anim.GetCurrentAnimatorStateInfo(0);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("kunai") || currentState.IsName(Attacks[0]) || currentState.IsName(Attacks[1]))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

}
