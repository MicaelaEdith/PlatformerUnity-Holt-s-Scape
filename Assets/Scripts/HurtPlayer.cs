using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int hurtP;
   
    private void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Player")
        {
            HealthManager.instance.Hurt(hurtP);

        }

    }

}
