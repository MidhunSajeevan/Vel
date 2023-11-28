using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Damagable : MonoBehaviour
{
    Animator _animatior;
    private int _maxHealth = 100;
    [SerializeField]
    private int _health = 100;
    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool IsInvincible = false;
    private float timeSincehit=0f  ;
    private float invinciblityTime=0.25f;

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;

            if(_health < 0)
            {
                IsAlive = false;
            }
        }
    }

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            _animatior.SetBool(AnimationStrings.IsAlive, value);
            Debug.Log("IS alive is set "+ value);
        }

    }


    private void Awake()
    {
        _animatior = GetComponent<Animator>();
    }
    private void Update()
    {
        if (IsInvincible)
        {
            if (timeSincehit > invinciblityTime)
            {
                IsInvincible=false;
                timeSincehit =0;
                
            }
            timeSincehit += Time.deltaTime;

        }
    
    }
    public void Hit(int damage)
    {
        if(IsAlive &&  !IsInvincible)
        {
            Health -=damage;
            IsInvincible = true;
        }

    }
}
