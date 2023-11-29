using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    CapsuleCollider2D touchingCollider;
    Animator animator;
    [SerializeField]
    ContactFilter2D castFilter;
    RaycastHit2D[] groundhits = new RaycastHit2D[5];
    RaycastHit2D[] wallhits = new RaycastHit2D[5];   
    RaycastHit2D[] cellinghits =new RaycastHit2D[5];
    public float groundDistance = 0.05f;
    public float wallDistane = 0.2f;
    public float cellingDistance = 0.05f;
    [SerializeField]
    private bool _isgrounded;
    [SerializeField]
    private bool _isonwall;
    [SerializeField]
    private bool _isoncelling;
    private Vector2 wallcheakdirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;


    public bool IsGrounded { get
           {
            return _isgrounded;
           }
        private set
         {
            _isgrounded = value;
            animator.SetBool(AnimationStrings.Isgrounded, value);
         }
    }

    public bool IsOnwall
    {
        get
        {
            return _isonwall;
        }
        private set
        {
            _isonwall = value;
            animator.SetBool(AnimationStrings.IsOnWall , value);
        }
    }
    public bool IsOncelling
    {
        get
        {
            return _isoncelling;
        }
        private set
        {
            _isoncelling = value;
            animator.SetBool(AnimationStrings.IsOnCelling , value); 
        }
    }
    private void Awake()
    {
        touchingCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }
  

    void FixedUpdate()
    {
     
        IsGrounded = touchingCollider.Cast(Vector2.down, castFilter, groundhits, groundDistance) > 0;
        IsOnwall = touchingCollider.Cast(wallcheakdirection, castFilter, wallhits, wallDistane) > 0;
        IsOncelling = touchingCollider.Cast(Vector2.up,castFilter , cellinghits , cellingDistance) > 0;
    }
}
