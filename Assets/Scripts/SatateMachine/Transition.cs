using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    public State TargetState => _targetState;
    public bool NeedTransit { get; protected set; }
    [SerializeField] private State _targetState;
    protected CharacterCard _attacker { get; private set; }
    protected CharacterCard _target { get; private set; }
    protected CharacterCard _swapAttacker { get; private set; }
    protected CharacterCard _swapTarget { get; private set; }
    protected Abillity _abillity { get; private set; }

    public void Init(CharacterCard attacker, CharacterCard swapAttacker, CharacterCard target, CharacterCard swapTarget, Abillity abillity)
    {
        _attacker = attacker;
        _swapAttacker = swapAttacker;
        _target = target;
        _swapTarget = swapTarget;
        _abillity = abillity;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

}
