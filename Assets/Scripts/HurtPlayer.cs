using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public bool isBird = false;
   
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

        if (other.tag == "Player")
        {
            HealthManager.instance.Hurt();

        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.playerAnimator.SetBool("Bird", false);

    }
}
