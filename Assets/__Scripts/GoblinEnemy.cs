using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoblinEnemy : Enemy
{
    public int enemyHealth;
    public Transform Player;
    //public Transform Player2;

    float moveSpeed = 0.5f;
    float range = 30f;
    float rotationSpeed = 3f;
    float stop = 0;

    public float enemyCooldown = 1;
    public int damage = 1;

    public Transform myTransform;
    
    //declare private variables
    private Rigidbody rigidBody;
    //for player 1:
    private bool playerInRange = false;
    private bool canAttack = true;

    //for player 2:
    // private bool playerInRange2 = false;
    // private bool canAttack2 = true;
    

    void Awake()
    {

        Player = GameObject.FindWithTag("Player").transform;//target player1
        //Player2 = GameObject.FindWithTag("Player2").transform; //target player2
        myTransform = transform; //cache transform data for easy access
    }

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        enemyHealth = 1;
    }



    void Update()
    {

        float distance = Vector3.Distance(myTransform.position, Player.position);
        //float distance2 = Vector3.Distance(myTransform.position, Player2.position);

        if(distance<=range)
        {
            //look
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Player.position-myTransform.position), rotationSpeed*Time.deltaTime);

            //move
            if(distance>stop)
            {
                myTransform.position+= myTransform.forward * moveSpeed * Time.deltaTime;
            }
        }
        // if(distance2<=range)
        // {
        //     //look
        //     myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(Player2.position-myTransform.position), rotationSpeed*Time.deltaTime);

        //     //move
        //     if(distance2>stop)
        //     {
        //         myTransform.position+= myTransform.forward * moveSpeed * Time.deltaTime;
        //     }
        // }
        
        if (playerInRange && canAttack)
        {
             GameObject.Find("Player").GetComponent<PlayerController>().currentHealth -= damage;
             StartCoroutine(AttackCooldown());
             if(GameObject.Find("Player").GetComponent<PlayerController>().currentHealth == 0)
             {
                 Invoke("Restart", 2); //restart the scene
             }
        }
        // if (playerInRange2 && canAttack2)
        // {
        //      GameObject.Find("Player2").GetComponent<PlayerController2>().currentHealth -= damage;
        //      StartCoroutine(AttackCooldown());
        //      if(GameObject.Find("Player2").GetComponent<PlayerController2>().currentHealth == 0)
        //      {
        //          Invoke("Restart", 2); //restart the scene
        //      }
        // }
    }

    void OnTriggerEnter(Collider coll)
    {
        //GameObject collideGO = coll.gameObject;
         if(coll.gameObject.CompareTag("Player"))
          {
             playerInRange = true;
         
            if(GameObject.Find("Player").GetComponent<PlayerController>().fight == true)
            {
            if(enemyHealth > 0)
            {
                enemyHealth -= damage;
            }
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            }
          }
        //  if (collideGO.CompareTag("Player2"))
        //   {
        //     playerInRange2 = true;
         
        //     if (GameObject.Find("Player2").GetComponent<PlayerController2>().fight2 == true)
        //     {
        //     if(enemyHealth > 0)
        //     {
        //         enemyHealth -= damage;
        //     }
        //     if(enemyHealth <= 0)
        //     {
        //         Destroy(gameObject);
        //     }
        //     }
        //}
        
        if(coll.gameObject.CompareTag("Sword") && (GameObject.Find("Player").GetComponent<PlayerController>().swing == true))
            {
            if(enemyHealth > 0)
            {
                enemyHealth -= damage;
            }
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            }

        // if(collideGO.CompareTag("Sword") && (GameObject.Find("Player2").GetComponent<PlayerController2>().swing2 == true))
        //     {
        //     if(enemyHealth > 0)
        //     {
        //         enemyHealth -= damage;
        //     }
        //     if(enemyHealth <= 0)
        //     {
        //         Destroy(gameObject);
        //     }
        //     }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("Player"));
        {
            playerInRange = false;
        }
    }

    IEnumerator AttackCooldown()
     {
        canAttack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canAttack = true;
     }

    public void Restart()
    {
        SceneManager.LoadScene("openingScene");
    }

}
