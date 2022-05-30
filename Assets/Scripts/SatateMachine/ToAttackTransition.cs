using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAttackTransition : Transition
{
    protected override void GetData()
    {
        if (_abillity.IsBaf == false)
            NeedTransit = true;
    }
}
