using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StaminaBar : MonoBehaviour
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
        OnStaminaChanged(_person.Stamina);
        if (_person != null)
        {
            _person.ChangeStamina += OnStaminaChanged;
        }
    }


    private void OnDisable()
    {
        if (_person != null)
            _person.ChangeStamina -= OnStaminaChanged;
    }

    private void OnStaminaChanged(int health)
    {
        _slider.DOValue((float)health / 100f, 1f);
    }
}
