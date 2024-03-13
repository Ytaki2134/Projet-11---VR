using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WalkState : State
{
    public AttackState attackState;
    public DeathState deathState;

    public Animator animator;

    public Enemy enemy;

    public override State RunCurrentState()
    {
        animator.SetBool("isWalking", true);

        if (enemy.transform.position.x < 125)
        {
            animator.SetBool("isAttacking", true);
            return attackState;
        }

        if (enemy.currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            return deathState;
        }

        return this;
    }
}
