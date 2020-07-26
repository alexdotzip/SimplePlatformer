using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : GenericDamage
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this one does it based off of a singleton

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && !other.isTrigger)
        {
            AudioManager.instance.PlaySFX(3);
            PlayerHealthController.instance.Damage(damage);
        }
    }
}
