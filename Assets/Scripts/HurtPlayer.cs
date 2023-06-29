using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public bool isBird = false;
    public bool fall = false;
    public CharacterController character;
    private Vector3 moveObject;
    float yStore;
   
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBird)
        {

            PlayerController.instance.playerAnimator.SetBool("Bird",true);
        }

        if (other.tag == "Player"&&!fall)
        {
            HealthManager.instance.Hurt();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.playerAnimator.SetBool("Bird", false);

        if (fall&&gameObject.transform.position.y < 3)
        {
            moveObject.y = gameObject.transform.position.y + 1f;
            character.Move(moveObject * Time.deltaTime*2);
            Debug.Log("Sube : "+gameObject.transform.position.y);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //reubicar barril con yStore

        if (other.tag=="Player" && fall)
        {
            if(gameObject.transform.position.y > -480f)
            {
                moveObject.y = gameObject.transform.position.y - 2f;
                character.Move(moveObject*Time.deltaTime);
                Debug.Log("Baje : "+gameObject.transform.position.y);
            }
        }
            
        
    }
}
