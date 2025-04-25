using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public Animator animator;

    public void TriggerAttack()
    {
        animator.SetTrigger("Attack");
    }
}
