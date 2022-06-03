using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class AbillityCard : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<Abillity> ChoosenAbility;
    public event UnityAction ChangeVisial;
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _targetSize;
    [SerializeField] private float _timeChange;
    private Image _image;
    private Text _text;
    private Abillity _abillity;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<Text>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChangeVisial?.Invoke();
        ChoosenAbility?.Invoke(_abillity);
        ChangeColorAndSize(_targetColor, _targetSize, _timeChange);
    }

    public void Init(Abillity abillity)
    {
        SetDefaultColor();
        _image.color = Color.white;
        _abillity = abillity;
        _image.sprite = _abillity.Sprite;
        _text.text = _abillity.Name;
    }

    private void ChangeColorAndSize(Color color,float size, float duration)
    {
        _image.DOColor(color, duration);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_rectTransform.DOScale(size, duration));
        sequence.Append(_rectTransform.DOScale(1f, duration));
    }

    public void SetDefaultColor()
    {
        _image.color = Color.white;
    }
}
