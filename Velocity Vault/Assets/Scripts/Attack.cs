    using UnityEngine;

public class Attack : MonoBehaviour
{

    public int damage = 10;
    public Vector2 knockBack = Vector2.zero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();
     
        
        if (damagable != null)
        {
            Vector2 deliveredKnockBack = transform.parent.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            damagable.Hit(damage, deliveredKnockBack);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
