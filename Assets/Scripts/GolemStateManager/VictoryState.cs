using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VictoryState : State
{
    public override State RunCurrentState()
    {
        return this;
    }
}
