using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int health, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        health = maxHealth;
        
    }

    void Update()
    {
        
    }

    public void Hurt(int hurt)
    {
        health-=hurt;
        if (health <= 0)
        {
            health = 0;
            GameManager.instance.Respawn();

        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void AddHealth(int healthPoints)
    {
        health += healthPoints;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }

}
