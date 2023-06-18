using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int healthAmount;
    public bool isFullHeal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            if (isFullHeal)
                HealthManager.instance.ResetHealth();
            else
                HealthManager.instance.AddHealth(healthAmount);
        }
    }
}
