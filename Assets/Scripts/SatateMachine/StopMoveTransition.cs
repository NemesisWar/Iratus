using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoveTransition : Transition
{
    private RectTransform _attackerRect;
    private RectTransform _swapAttackerRect;
    private RectTransform _targerRect;
    private RectTransform _swapTargetRect;
    private Vector2 _destinationAttaker;
    private Vector2 _destinationTarget;

    private void Start()
    {
        _attackerRect = _attacker.GetComponent<RectTransform>();
        _swapAttackerRect = _swapAttacker.GetComponent<RectTransform>();
        _targerRect = _target.GetComponent<RectTransform>();
        _swapTargetRect = _swapTarget.GetComponent<RectTransform>();
        _destinationAttaker = (Vector2)_swapAttackerRect.anchoredPosition;
        _destinationTarget = (Vector2)_swapTargetRect.anchoredPosition;
        //Debug.Log($"START{_attackerRect.anchoredPosition} {_destinationAttaker}");

    }

    private void Update()
    {
        //Debug.Log($"{_attackerRect.anchoredPosition} {_destinationAttaker}");
        if ((_attackerRect.anchoredPosition == _destinationAttaker) && (_targerRect.anchoredPosition == _destinationTarget))
        {
            NeedTransit = true;
            Debug.Log("STOP");
        }          
    }
}
