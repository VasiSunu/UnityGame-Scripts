using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement1 movement; 

    void Update()
    {
        Vector2 lastDir = movement.lastMoveDir;
        Vector2 dir = movement.moveDir;

        animator.SetFloat("Horizontal", lastDir.y);
        animator.SetFloat("Vertical", lastDir.x);
        animator.SetBool("isMoving", dir != Vector2.zero);
    }

    public void TriggerAttack()
    {
        animator.SetTrigger("Attack");
    }
}

