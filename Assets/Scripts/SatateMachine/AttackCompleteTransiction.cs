using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCompleteTransiction : Transition
{
    private void OnDisable()
    {
        _attacker.PersonInThisCell.AttackCompleted -= OnAttackComplited;
    }

    private void OnAttackComplited()
    {
        NeedTransit = true;
    }

    protected override void GetData()
    {
        _attacker.PersonInThisCell.AttackCompleted += OnAttackComplited;
    }
}
