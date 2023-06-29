using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowController : MonoBehaviour
{
    public int sfx;
    public bool slowSFX = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.slow = true;
            PlayerController.instance.moveSpeed = 1.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.instance.slow = false;
        PlayerController.instance.moveSpeed = 20f;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player" && !slowSFX)
            AudioManager.instance.PlaySFX(sfx);

       /* if (PlayerController.instance.playerAnimator.GetFloat("Slow") > 0.1)
            slowSFX = true;
        else
            slowSFX = false;*/


    }
}
