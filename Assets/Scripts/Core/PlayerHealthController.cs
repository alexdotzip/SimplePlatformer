using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : GenericHealth
{
    // inherited from GenericHealth.cs --> public int currentHealth, maxHealth;

    // Start is called before the first frame update
    public static PlayerHealthController instance;


    public float invincibleLength;
    private float invincibleCounter;

    private SpriteRenderer mySpriteRenderer;

    public GameObject deathEffect;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;

        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;

            if(invincibleCounter <= 0)
            {
                mySpriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
    public override void Damage(float amountToDamage)
    {

        if (invincibleCounter <= 0)
        {
            currentHealth -= amountToDamage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);
                //Debug.Log("Player Died!!");

                Instantiate(deathEffect, transform.position, transform.rotation);
                AudioManager.instance.PlaySFX(5);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, .1f, .1f, .5f);

                PlayerController.instance.Knockback();
            }
            UIController.instance.UpdateHearts();
        }

    }

    public override void InstantDeath()
    {
        currentHealth = 0;
        gameObject.SetActive(false);
    }

    public override void Heal(float amountToHeal)
    {
        base.Heal(amountToHeal);
        UIController.instance.UpdateHearts();
    }

}
