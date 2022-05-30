using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;
    protected CharacterCard _attacker { get; set; }
    protected CharacterCard _swapAttacker { get; set; }
    protected CharacterCard _swapTarget { get; set; }
    protected CharacterCard _target { get; set; }
    protected Abillity _abillity { get; set; }

    protected abstract void OnEnable();
    public void Enter(CharacterCard attacker, CharacterCard swapAttacker, CharacterCard target, CharacterCard swapTarget, Abillity abillity)
    {
        if(enabled == false)
        {
            _attacker = attacker;
            _swapAttacker = swapAttacker;
            _target = target;
            _swapTarget = swapTarget;
            _abillity = abillity;
            enabled = true;

            foreach(Transition transition in _transitions)
            {
                transition.Init(_attacker, _swapAttacker, _target, _swapTarget, _abillity);
                transition.enabled = true;
            }
        }
    }

    public void Exit()
    {
        if(enabled == true)
        {
            foreach (Transition transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach (Transition transition in _transitions)
        {
            if(transition.NeedTransit == true)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
