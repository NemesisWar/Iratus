using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaffState : State
{
    protected override void OnEnable()
    {
        _attacker.PersonInThisCell.GetComponent<Person>().Baff(_abillity);
    }
}
