using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AttackState : State
{

    public WalkState walkState;
    public DeathState deathState;
    public VictoryState victoryState;

    

    public override State RunCurrentState()
    {
        if (walkState.enemy.currentHealth <= 0)
        {
            walkState.baseScript.totalDamage -= walkState.enemy.damage;
            walkState.enemy.isMoving = false;
            walkState.animator.SetBool("isDead", true);
            return deathState;
        }

        if (walkState.baseScript.hp <= 0)
        {
            walkState.baseScript.totalDamage -= walkState.enemy.damage;
            walkState.animator.SetBool("hasWon", true);
            return victoryState;
        }

        return this;
    }
}
