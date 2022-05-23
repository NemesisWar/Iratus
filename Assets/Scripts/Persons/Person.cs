using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Spine.Unity;

public class Person : MonoBehaviour
{
    public event UnityAction <int> ChangeHealth;
    public event UnityAction <int> ChangeStamina;
    public int Health => _health;
    public int Stamina => _stamina;
    public List<Abillity> Abillities => _abilities;

    [SerializeField] private int _health;
    [SerializeField] private int _stamina;
    [SerializeField] private SkeletonGraphic _skeletonGraphic; //времянка
    [SerializeField] private List <Abillity> _abilities;

    private void OnValidate()
    {
        if (_health > 100)
            _health = 100;
        if(_stamina > 100)
            _stamina = 100;
    }

    public void Init()//времянка
    {
        foreach (var item in _abilities)
        {
            item.Init(_skeletonGraphic, this);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangeHealth?.Invoke(_health);
        if (_health < 0)
        {
            
        }
    }

    public void SpendStamina(int stamina)
    {
        _stamina -= stamina;
        ChangeStamina?.Invoke(_stamina);
        if (stamina < 0)
        {
           
        }
    }
}
