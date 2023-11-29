using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeRemoveBehaviour : StateMachineBehaviour
{
    public float fadeTimeOut;
    private float TimeElapsed = 0;
    private SpriteRenderer _spriteRenderer;
    private GameObject _gameObject;
    private Color _color;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        TimeElapsed = 0;
        _spriteRenderer = animator.GetComponent<SpriteRenderer>();
        _gameObject = animator.gameObject;
        _color = _spriteRenderer.color;
      
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        TimeElapsed += Time.deltaTime;
        float newAlpha = _color.a*(1-(TimeElapsed/fadeTimeOut));
        _spriteRenderer.color = new Color(_color.r, _color.g, _color.b, newAlpha);
        if (TimeElapsed > fadeTimeOut)
        {
            Destroy(_gameObject);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
