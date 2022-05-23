using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AbillityCard : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<Abillity> ChoosenAbility;
    private Image _image;
    private Text _text;
    private Abillity _abillity;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<Text>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChoosenAbility?.Invoke(_abillity);
    }

    public void Init(Abillity abillity)
    {
        _abillity = abillity;
        _image.sprite = _abillity.Sprite;
        _text.text = _abillity.Name;
    }
}
