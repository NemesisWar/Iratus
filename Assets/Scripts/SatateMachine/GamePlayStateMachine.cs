using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayStateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    [SerializeField] private State _fistState;
    private State _currentState;
    [SerializeField] private CharacterCard _attacker;
    [SerializeField] private CharacterCard _swapAttacker;
    [SerializeField] private CharacterCard _target;
    [SerializeField] private CharacterCard _swapTarget;
    [SerializeField] private Abillity _abillity;

    private void Start()
    {
        Reset(_fistState);
        //_fistState.Enter(_attacker, _swapAttacker, _target, _swapTarget, _abillity);
    }

    public void Init(CharacterCard attacker, CharacterCard target, Abillity abillity)
    {
        _attacker = attacker;
        _target = target;
        _abillity = abillity;
        enabled = true;
    }

    private void Reset(State startState)
    {
        _currentState = startState;
        if(_currentState != null)
        {
            _currentState.Enter(_attacker, _swapAttacker, _target, _swapTarget, _abillity);
        }
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
            Transit(nextState);

    }

    private void Transit(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if (_currentState != null)
        {
            _currentState.Enter(_attacker, _swapAttacker, _target, _swapTarget, _abillity);
        }
    }
}
