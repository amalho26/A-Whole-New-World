using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public int currentHealth;
    public Text playerHealth;

    public Animator animator;
    public int isWalkingHash;
    public int isBackwardHash;
    public int isJumpingHash;
    public int isRunningHash;
    public int isSwingingHash;
    //public int isSwingingHash2;
    public int isFightingHash;
    //public int isFightingHash2;

    public int damage = 1;

    public bool fight = false;
    public bool swing = false;


    public float speed = 10f;



    //Start is called before the first frame update
    public virtual void Start()
    {

        currentHealth = 50; //set initial player health at 50
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isBackwardHash = Animator.StringToHash("isBackward");
        isJumpingHash = Animator.StringToHash("isJumping");
        isRunningHash = Animator.StringToHash("isRunning");
        isSwingingHash = Animator.StringToHash("isSwinging");
        //isSwingingHash2 = Animator.StringToHash("isSwinging2");
        isFightingHash = Animator.StringToHash("isFighting");
        //isFightingHash2 = Animator.StringToHash("isFighting2");

    }

    //Update is called once per frame
    public void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey(KeyCode.UpArrow);
        bool isBackward = animator.GetBool("isBackward");
        bool backwardPressed = Input.GetKey(KeyCode.DownArrow);
        bool isJumping = animator.GetBool("isJumping");
        bool jumpingPressed = Input.GetKey(KeyCode.Z);
        bool isRunning = animator.GetBool("isRunning");
        bool runningPressed = Input.GetKey(KeyCode.X);
        bool isSwinging = animator.GetBool("isSwinging");
        bool swingingPressed = Input.GetKey(KeyCode.Space);    
        bool isFighting = animator.GetBool("isFighting");
        bool fightingPressed = Input.GetKey(KeyCode.B);
        // bool isSwinging2 = animator.GetBool("isSwinging2");
        // bool swingingPressed2 = Input.GetKey(KeyCode.Space);    
        // bool isFighting2 = animator.GetBool("isFighting2");
        // bool fightingPressed2 = Input.GetKey(KeyCode.B);

        SetHealthText();


        transform.position += transform.forward * speed * Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            transform.Rotate(0.0f, -90.0f, 0.0f);
        }

      
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            transform.Rotate(0.0f, 90.0f, 0.0f);
        }
        
        //if player pressed forward key (or up arrow)
        if(forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if(!forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        //if player pressed backward key (or down arrow)
        if(backwardPressed)
        {
            animator.SetBool(isBackwardHash, true);
        }
        if(!backwardPressed)
        {
            animator.SetBool(isBackwardHash, false);
        }

        //if player pressed the Z key 
        if(jumpingPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        if(!jumpingPressed)
        {
            animator.SetBool(isJumpingHash, false);
        }

        //if player pressed the x key 
        if(runningPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        if(!runningPressed)
        {
            animator.SetBool(isRunningHash, false);
        }
        //if player pressed Space key 
        if(swingingPressed)
        {
            animator.SetBool(isSwingingHash, true);
            swing = true;
        }
        if(!swingingPressed)
        {
            animator.SetBool(isSwingingHash, false);
            swing = false;
        }
         //if player pressed B key 
        if(fightingPressed)
        {
            animator.SetBool(isFightingHash, true);
            fight = true;
        }
        if(!fightingPressed)
        {
            animator.SetBool(isFightingHash, false);
            fight = false;
        }

    }

    public virtual void Fight()
    {
    }
    public virtual void Swing()
    {
    }

    public void SetHealthText()
    {
        playerHealth.text = "Player health: " + currentHealth.ToString();
    }


}
