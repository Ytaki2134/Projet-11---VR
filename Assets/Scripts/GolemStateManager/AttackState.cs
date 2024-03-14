using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackState : State
{

    public WalkState walkState;
    public DeathState deathState;

    public override State RunCurrentState()
    {
        if (walkState.enemy.currentHealth <= 0)
        {
            walkState.enemy.isMoving = false;
            walkState.animator.SetBool("isDead", true);
            return deathState;
        }
        return this;
    }
}
