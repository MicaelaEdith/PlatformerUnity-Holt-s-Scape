using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowController : MonoBehaviour
{
    public int sfx;

    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.slow = true;
            PlayerController.instance.moveSpeed = 1.5f;
            BirdController.instance.attack = true;
            
        }

    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.slow = false;
        PlayerController.instance.moveSpeed = 20f;
        AudioManager.instance.StopSFX(sfx);
        BirdController.instance.attack = false;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            AudioManager.instance.PlaySFX(sfx);


    }
}
