using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    public UnityEvent OnGameOver;
    
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
        OnGameOver?.Invoke();

    }
    private void OnEnable()
    {
        CharectorEvents.playerDead += Endthegame;
    }
}
