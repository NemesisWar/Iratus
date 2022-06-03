using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Spine.Unity;
using Spine;
using System;

public class Person : MonoBehaviour
{
    public event UnityAction <int> ChangeHealth;
    public event UnityAction <int> ChangeStamina;
    public event UnityAction AttackCompleted;
    public event UnityAction Die;
    public int Health => _health;
    public int Stamina => _stamina;

    public List<Abillity> Abillities => _abilities;

    [SerializeField] private int _health;
    [SerializeField] private int _stamina;
    [SerializeField] private SkeletonGraphic _skeletonGraphic;
    [SerializeField] private List <Abillity> _abilities;
    [SerializeField] private AnimationReferenceAsset _damageAnimation;
    [SerializeField] private AnimationReferenceAsset _idle;
    private Person _enemyPerson = null;
    private Abillity _attackAbillity = null;
   

    private void Start()
    {
        _skeletonGraphic.AnimationState.Event += AnimationEvent;
        _skeletonGraphic.AnimationState.Complete += OnComplete ;
    }

    private void OnComplete(TrackEntry trackEntry)
    {
        PlayAnimation(_idle, true, 1f);
        AttackCompleted?.Invoke();
    }

    private void AnimationEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "Hit")
        {
            _enemyPerson.TakeDamage(_attackAbillity.Damage);
        }
    }

    private void OnValidate()
    {
        if (_health > 100)
            _health = 100;
        if(_stamina > 100)
            _stamina = 100;
    }

    public void TakeDamage(int damage)
    {
        PlayAnimation(_damageAnimation, false, 1f);
        _health -= damage;
        ChangeHealth?.Invoke(_health);
        if (_health <= 0)
        {
            Dead();
        }
    }

    public void SpendStamina(int stamina)
    {
        _stamina -= stamina;
        ChangeStamina?.Invoke(_stamina);
        if (stamina > 100)
        {
            _stamina = 100;
        }
    }

    public void Attack(Abillity abillity, Person person)
    {
        ClearAbilityAndEnemy();
        _enemyPerson = person;
        _attackAbillity = abillity;
        PlayAnimation(_attackAbillity.AnimationReferenceAsset, false, 1f);
        SpendStamina(_attackAbillity.UseStamina);
    }

    private void ClearAbilityAndEnemy()
    {
        _enemyPerson = null;
        _attackAbillity = null;
    }

    public void Baff(Abillity abillity)
    {
        SpendStamina(abillity.UseStamina);
    }

    private void PlayAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        _skeletonGraphic.AnimationState.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }

    private void Dead()
    {
        Die?.Invoke();
    }

}
