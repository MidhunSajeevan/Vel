
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D), typeof (TouchingDirection))]
public class EnemyMovements : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    private float speed =2f;
    [Range(0f,0.5f)]
    public float breakSpeed;
    private Vector2 _walkDirectionVector= Vector2.right;
    private TouchingDirection _touchingDirection;
    [SerializeField]
    private DetectionZone _detectionZone;
    [SerializeField]
    private DetectionZone _clifDetectionZone;
    public enum WalkableDirection{ right, left }

    private WalkableDirection   _walkDirecton;
    private bool _hasTarget;
    private Animator _animator;
    private Damagable _damagable;
    public WalkableDirection WalkDirection
    {
        get { return _walkDirecton; }
        set{
            if(_walkDirecton != value)
            {
                gameObject.transform.localScale= new Vector2(gameObject.transform.localScale.x * -1,gameObject.transform.localScale.y);
                if(value == WalkableDirection.right)
                {
                    _walkDirectionVector = Vector2.right;
                }else if(value == WalkableDirection.left)
                {
                    _walkDirectionVector = Vector2.left;
                }
            }
            _walkDirecton = value;
            }
    }

    public bool CanMove
    {
        get
        {
            return _animator.GetBool(AnimationStrings.CanMove);
        }
    }
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
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _touchingDirection = GetComponent<TouchingDirection>();
        _animator = GetComponent<Animator>();
        _damagable = GetComponent<Damagable>();
    }

    private void Update()
    {
        HasTarget = _detectionZone._colliders.Count > 0;
    }

    void FixedUpdate()
    {
        if (CanMove) 
        {
            if(!_damagable.IsHit)
                _rigidbody.velocity = new Vector2(speed * _walkDirectionVector.x, _rigidbody.velocity.y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(Mathf.Lerp(_rigidbody.velocity.x , 0 , breakSpeed ), _rigidbody.velocity.y );
        }
       
        if(_touchingDirection.IsGrounded && _touchingDirection.IsOnwall || _clifDetectionZone._colliders.Count == 0)
        {
            FlipDirecion();
        }
    }
    void FlipDirecion()
    {
        if (WalkDirection == WalkableDirection.right)
        {
            WalkDirection = WalkableDirection.left;
        }else if(WalkDirection == WalkableDirection.left)
        {
            WalkDirection = WalkableDirection.right;
        }
        else
        {
            Debug.LogError("Not Working ");
        }
    }
    public void OnHit(int damage, Vector2 knockBack)
    {
        _rigidbody.velocity = new Vector2(knockBack.x, _rigidbody.velocity.y + knockBack.y);
    }
}
