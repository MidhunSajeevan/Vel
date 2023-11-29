using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUps : MonoBehaviour
{
    public int healthRestore = 20;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.GetComponent<Damagable>();
        if(damagable)
        {
           bool washealed = damagable.Heal(healthRestore);
            if(washealed)
                Destroy(gameObject);
        }
    }

}
