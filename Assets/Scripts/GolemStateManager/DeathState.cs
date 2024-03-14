using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DeathState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
