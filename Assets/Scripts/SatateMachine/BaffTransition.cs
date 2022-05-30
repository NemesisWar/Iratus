using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaffTransition : Transition
{
    protected override void GetData()
    {
        if (_abillity.IsBaf == true)
            NeedTransit = true;
    }
}
