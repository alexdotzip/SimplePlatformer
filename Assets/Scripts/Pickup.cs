using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //TODO split these into their own respective classes

    //TODO Gem Pickup Class
    public bool isGem;

    //TODO Health Pickup Class
    public bool isHeal;
    [SerializeField] private int amountToHeal;

    private bool isCollected;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.CompareTag("Player") && !other.isTrigger) && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);

                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();
            }

            if(isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.Heal(amountToHeal);
                    isCollected = true;
                    Destroy(gameObject);

                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
