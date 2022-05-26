using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCompleteTransiction : Transition
{
    private void Start()// Нужно будет сделать OnEnable
    {
        _attacker.PersonInThisCell.AttackCompleted += OnAttackComplited;
    }

    private void OnDisable()
    {
        _attacker.PersonInThisCell.AttackCompleted -= OnAttackComplited;
    }

    private void OnAttackComplited()
    {
        NeedTransit = true;
    }
}
