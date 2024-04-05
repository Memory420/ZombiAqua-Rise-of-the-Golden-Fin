using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;

    // Идентификаторы параметров анимации
    private readonly int isRunningHash = Animator.StringToHash("IsRunning");
    private readonly int jumpHash = Animator.StringToHash("Jump");
    private readonly int attackHash = Animator.StringToHash("Attack");
    private readonly int strongAttackHash = Animator.StringToHash("StrongAttack");
    private readonly int speedJumpHash = Animator.StringToHash("SpeedJump");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Run(bool isRunning)
    {
        animator.SetBool(isRunningHash, isRunning);
    }

    public void Jump()
    {
        animator.SetTrigger(jumpHash);
    }

    public void Attack()
    {
        animator.SetTrigger(attackHash);
    }

    public void StrongAttack()
    {
        animator.SetTrigger(strongAttackHash);
    }
    public void SpeedJump ()
    {
        animator.SetTrigger(speedJumpHash);
    }
}
