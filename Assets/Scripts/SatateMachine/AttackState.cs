using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected override void OnEnable()
    {
        _attacker.PersonInThisCell.GetComponent<Person>().Attack(_abillity, _target.PersonInThisCell.GetComponent<Person>());
    }
}
