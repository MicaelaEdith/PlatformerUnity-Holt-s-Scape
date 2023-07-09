using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Vector3 startPosition; 

    public Animator birdAnimator;
    public static BirdController instance;
    public bool attack = false;
    private bool goAttack = true;
    
   

    private void Awake()
    {
        instance = this;
        startPosition = transform.position;
       
    }

    void Start()
    {
        
        
    }

    
    void Update()
    {

            


        if (attack)
            Invoke("Attack",1.5f);
        else
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 30f * Time.deltaTime);
        if (transform.position == startPosition)
        {
            birdAnimator.SetBool("Idle", true);
            
        }

    }

    private void Attack()
    {
        if (birdAnimator.GetBool("Idle"))
            birdAnimator.SetBool("Idle", false);

        if (goAttack)
            transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.enemyTarget.transform.position, 20f * Time.deltaTime);
        else
            Invoke("goBack",1F);
    }
    private void goBack()
    {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 20f * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
            
        if (transform.position == startPosition&&!goAttack)
            {
                goAttack = true;
                transform.rotation = Quaternion.Euler(0f, 180, 0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            attack = false;
            HealthManager.instance.Hurt(1);
            birdAnimator.SetBool("Attack", true);
            goAttack = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        birdAnimator.SetBool("Attack", false);
        
    }

}
