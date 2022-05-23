using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{
    public event UnityAction <int> ChangeHealth;
    public event UnityAction <int> ChangeStamina;

    [SerializeField] private int _health;
    [SerializeField] private int _stamina;
    [SerializeField] private List <Abillity> _abilities;

    private void OnValidate()
    {
        if (_health > 100)
            _health = 100;
        if(_stamina > 100)
            _stamina = 100;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            ChangeHealth?.Invoke(_health);
        }
    }

    public void SpendStamina(int stamina)
    {
        _stamina -= stamina;
        if(stamina < 0)
        {
            ChangeStamina?.Invoke(_stamina);
        }
    }
}
