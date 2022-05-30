using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCards : State
{
    [SerializeField] private float _timeToMove;
    private RectTransform _attackerRect;
    private RectTransform _swapAttackerRect;
    private RectTransform _targerRect;
    private RectTransform _swapTargetRect;

    protected override void OnEnable()
    {
        _attackerRect = _attacker.GetComponent<RectTransform>();
        _swapAttackerRect = _swapAttacker.GetComponent<RectTransform>();
        _targerRect = _target.GetComponent<RectTransform>();
        _swapTargetRect = _swapTarget.GetComponent<RectTransform>();
        StartMove();
    }

    private void StartMove()
    {
        _attackerRect.DOAnchorPos(_swapAttackerRect.anchoredPosition, _timeToMove);
        _swapAttackerRect.DOAnchorPos(_attackerRect.anchoredPosition, _timeToMove);
        _targerRect.DOAnchorPos(_swapTargetRect.anchoredPosition, _timeToMove);
        _swapTargetRect.DOAnchorPos(_targerRect.anchoredPosition, _timeToMove);
    }
}
