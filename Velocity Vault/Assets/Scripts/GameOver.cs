using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject gameover;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Endthegame();
        }
       
    }
    void Endthegame()
    {
        Destroy(player);
        gameover.SetActive(true);
    }
    private void OnEnable()
    {
        CharectorEvents.playerDead += Endthegame;
    }
}
