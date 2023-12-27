using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const string IS_MOVING = "IsMoving";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector2 movement = InputManager.Instance.GetPlayerMovement();
        if (movement.magnitude < 0.01f)
        {
            animator.SetBool(IS_MOVING,false);
            return;
        }
        animator.SetBool(IS_MOVING, true);
    }
}
