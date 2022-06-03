using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayStateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    [SerializeField] private State _fistState;
    [SerializeField] private CharacterCard _swapPlayer;
    [SerializeField] private CharacterCard _swapEnemy;
    private Abillity _abillity;
    private State _currentState;
    private CharacterCard _attacker;
    private CharacterCard _target;
    private CharacterCard _swapAttacker;
    private CharacterCard _swapTarget;

    public void Init(CharacterCard attacker, CharacterCard target, Abillity abillity)
    {
        Cursor.visible = false;
        if (attacker.IsEnemy == false)
        {
            _swapAttacker = _swapPlayer;
            _swapTarget = _swapEnemy;
        }
        if (attacker.IsEnemy == true)
        {
            _swapAttacker = _swapEnemy;
            _swapTarget = _swapPlayer;
        }
        _attacker = attacker;
        _target = target;
        _abillity = abillity;
        enabled = true;
        Reset(_fistState);
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
