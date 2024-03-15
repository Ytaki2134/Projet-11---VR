using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WalkState : State
{
    public AttackState attackState;
    public DeathState deathState;
    public VictoryState victoryState;

    public Animator animator;

    public Enemy enemy;
    [HideInInspector] public Base baseScript;

    public override State RunCurrentState()
    {
        if (baseScript == null)
            baseScript = GameObject.FindGameObjectWithTag("Base").GetComponent<Base>();

        animator.SetBool("isWalking", true);

        if (Vector3.Distance(enemy.transform.position, enemy.targetToFocus.transform.position) < 20)
        {
            enemy.isMoving = false;
            animator.SetBool("isAttacking", true);
            baseScript.totalDamage += enemy.damage;
            return attackState;
        }

        if (enemy.currentHealth <= 0)
        {
            enemy.isMoving = false;
            animator.SetBool("isDead", true);
            return deathState;
        }

        if (baseScript.hp <= 0)
        {
            enemy.isMoving = false;
            animator.SetBool("hasWon", true);
            return victoryState;
        }

        return this;
    }
}
