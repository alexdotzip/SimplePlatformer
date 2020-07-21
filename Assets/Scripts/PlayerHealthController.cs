using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : GenericHealth
{
    // inherited from GenericHealth.cs --> public int currentHealth, maxHealth;

    // Start is called before the first frame update
    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public override void Damage(float amountToDamage)
    {
        currentHealth -= amountToDamage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            Debug.Log("Player Died!!");
        }


    }

    public override void InstantDeath()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }


}
