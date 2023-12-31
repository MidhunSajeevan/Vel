using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public UnityEvent<int> onTakeDamage;
    public UnityEvent<int> onHealthRestored;

    private static int enemyCount = 0;

    public static int EnemyCount
    {
        get { return enemyCount; }
    }

    private void OnDestroy()
    {
        enemyCount++;
    }

    public bool IsHit {
        get
        {
            return _animatior.GetBool(AnimationStrings.IsHit);
        }
        private set
        {
            _animatior.SetBool(AnimationStrings.IsHit, value);  
        }
    }

    private float timeSincehit=0f  ;
    private float invinciblityTime=0.25f;
    public UnityEvent<int, Vector2> damagableHit;
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
    public bool Hit(int damage,Vector2 knockBack)
    {
        if(IsAlive &&  !IsInvincible)
        {
            Health -=damage;
            IsInvincible = true;
            IsHit = true;
            damagableHit?.Invoke(damage, knockBack);
            onTakeDamage?.Invoke(Health);
            CharectorEvents.charectorDamaged.Invoke(gameObject, damage);
            return true;
        }
        return false;
    }
    public bool Heal(int healthResore)
    {
        if (IsAlive && Health<_maxHealth)
        {
            int Maxheal= Mathf.Max(_maxHealth-Health,0);
            int actualhealth = Mathf.Max(Maxheal, healthResore);
            Health += actualhealth; 
            onHealthRestored?.Invoke(Health);
            CharectorEvents.charectorHealed.Invoke(gameObject, actualhealth);
            return true;
        }
        return false;
    }
   
}
