using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeScript : MonoBehaviour
{
    public DetectionZone detectionZone;
    private bool _hasTarget;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    public List<Transform> _waypoints;
    private float _speed = 4f;
    private Damagable damagabel;
    private Transform _nextWaypoint;
    private int _wayPointNum = 0;
    private float WayPointReachedDistance=0.1f;

    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            _animator.SetBool(AnimationStrings.HasTarget, value);
        }
    }
    public bool CanMove
    {
        get
        {
            return _animator.GetBool(AnimationStrings.CanMove);
        }
    }
    private void Awake()
    {
        
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        damagabel = GetComponent<Damagable>();
    }
    private void Start()
    {
        _nextWaypoint = _waypoints[_wayPointNum];
    }

    void Update()
    {
        HasTarget = detectionZone._colliders.Count > 0;
        if (damagabel.IsAlive)
        {
            if (CanMove)
            {
                Flight();
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            _rigidbody.gravityScale = 2f;
           
        }
    }
  
    void Flight()
    {
        //Fly to next waypoint
        Vector2 directionToWaypoint = (_nextWaypoint.position - transform.position).normalized;

        //cheak if we have reached waypoint already
        float distance = Vector2.Distance(_nextWaypoint.position, transform.position);

        _rigidbody.velocity = directionToWaypoint * _speed;
        UpdateDirection();
        // see if we needs to switch waypoints
        if (distance <= WayPointReachedDistance)
        {
            _wayPointNum++;
            if(_wayPointNum >= _waypoints.Count)
            {
                _wayPointNum = 0;
            }
            _nextWaypoint = _waypoints[_wayPointNum];   
        }

    }

    private void UpdateDirection()
    {
        Vector3 localScale = transform.localScale;

        if(transform.localScale.x > 0)
        {
            if (_rigidbody.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1*localScale.x,localScale.y,localScale.z);
            }
        }
        else
        {
            if (_rigidbody.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }
        }
    }
    
}
