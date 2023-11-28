using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public int damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();

        if (damagable != null)
        {
            damagable.Hit(damage);
        }
    }
}
