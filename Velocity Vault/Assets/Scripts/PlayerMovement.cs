using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [Header("Player Settings")]
    [Range(0, 10)]
    [SerializeField] float speed = 5f;
    private Rigidbody2D _rigidbody;
    private Vector2 _inputMovment;
    private Animator _animator;
    private float jumpImpuse= 10f;
    private bool _isMoving=false;
    TouchingDirection touchingDirection;
    private float currentspeed;
    private Damagable _damagable;

                       
    public bool CanMove {  get
        {
            return _animator.GetBool(AnimationStrings.CanMove);
        }
    }
    public bool IsMoving { get
        { 
            return _isMoving;
        }  private set
        {
            _isMoving = value;
            _animator.SetBool(AnimationStrings.IsRunning, _isMoving);
        }
    }

    public bool _isfacingRight = true;
  

    public bool IsFacingRight 
        {    get
             {
               return _isfacingRight;
             }
            private set
             {
                 if( _isfacingRight != value )
                 {
                   transform.localScale *= new Vector2(-1, 1);
                 }
                 _isfacingRight = value;
             }
           
         }

    public bool IsAlive
    {
        get
        {
           return _animator.GetBool(AnimationStrings.IsAlive);
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        touchingDirection = GetComponent<TouchingDirection>();  
        _damagable = GetComponent<Damagable>();
        _damagable.damagableHit.AddListener(OnHit);
    }
   
    private void FixedUpdate()
    {

        Movement();
        
    }
    void Movement()
    {
        if(CanMove)
        {
            currentspeed = touchingDirection.IsOnwall ? 0f : speed;
            if(!_damagable.IsHit)
                _rigidbody.velocity = new Vector2(_inputMovment.x * currentspeed, _rigidbody.velocity.y);
            _animator.SetFloat(AnimationStrings.Yvelocity, _rigidbody.velocity.y);
        }
    }
      
    public void Move(InputAction.CallbackContext input)
    {
        _inputMovment = input.ReadValue<Vector2>();
        if (IsAlive)
        {
           
            SetFacingDirection(_inputMovment);
            IsMoving = _inputMovment != Vector2.zero;
        }
        else
        {
            IsMoving = false;
        }
    
       
    }
    private void SetFacingDirection(Vector2 moveInput)
    {
     if(_inputMovment.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;

        }else if(_inputMovment.x < 0 && IsFacingRight)
        {
            IsFacingRight=false;
        }

    }
    public void onJump(InputAction.CallbackContext input)
    {
        //To do cheak if the player is dead or not
        if(input.started && touchingDirection.IsGrounded && CanMove)
        {
            _animator.SetTrigger(AnimationStrings.Jump);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpImpuse);
        }
    }

    public void OnAttack(InputAction.CallbackContext input)
    {
        if(input.started)
        {
            _animator.SetTrigger(AnimationStrings.AttackTrigger);
        }
    }
    public void OnHit(int damage , Vector2 knockBack)
    {
     
        _rigidbody.velocity = new Vector2(knockBack.x, _rigidbody.velocity.y+knockBack.y);
    }
}
