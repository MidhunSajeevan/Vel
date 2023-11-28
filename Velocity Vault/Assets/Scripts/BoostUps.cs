using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUps : MonoBehaviour
{
    static int boostCount = 0;
    [SerializeField]
    private Text pro;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            Destroy(this.gameObject);
            boostCount++;
            pro.text = boostCount.ToString();
        }
    }

}
