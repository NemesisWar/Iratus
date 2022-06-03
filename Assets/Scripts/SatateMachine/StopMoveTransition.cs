using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveTransition : Transition
{
    [SerializeField] private float _faultDistance;
    private RectTransform _attackerRect;
    private RectTransform _swapAttackerRect;
    private RectTransform _targerRect;
    private RectTransform _swapTargetRect;
    private Vector2 _destinationAttaker;
    private Vector2 _destinationTarget;

    protected override void GetData()
    {
        _attackerRect = _attacker.GetComponent<RectTransform>();
        _swapAttackerRect = _swapAttacker.GetComponent<RectTransform>();
        _targerRect = _target.GetComponent<RectTransform>();
        _swapTargetRect = _swapTarget.GetComponent<RectTransform>();
        _destinationAttaker = _swapAttackerRect.anchoredPosition;
        _destinationTarget = _swapTargetRect.anchoredPosition;
    }

    private void Update()
    {     
        if((Vector2.Distance(_attackerRect.anchoredPosition, _destinationAttaker)< _faultDistance) && (Vector2.Distance(_targerRect.anchoredPosition, _destinationTarget) < _faultDistance))
        {
            NeedTransit = true;
        }
    }
}
