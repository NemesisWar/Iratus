using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HeathBar : MonoBehaviour
{
    private Slider _slider;
    private Person _person;

    private void Awake()
    {
        _slider = GetComponent<Slider>();  
    }

    public void Init(Person person)
    {
        _person = person;
        OnHealthChanged(_person.Health);
        if (_person != null)
        {
            _person.ChangeHealth += OnHealthChanged;
        }
    }

    private void OnEnable()
    {
        if(_person != null)
            _person.ChangeHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        if( _person != null)
            _person.ChangeHealth -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _slider.DOValue((float)health/100f, 1f);
    }
}
