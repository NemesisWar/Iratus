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
    public int Health => _health;
    public int Stamina => _stamina;

    public bool IsWalked => _isWalked;
    public List<Abillity> Abillities => _abilities;

    [SerializeField] private bool _isWalked;
    [SerializeField] private int _health;
    [SerializeField] private int _stamina;
    [SerializeField] private SkeletonGraphic _skeletonGraphic; //времянка
    [SerializeField] private List <Abillity> _abilities;
    [SerializeField] private AnimationReferenceAsset _damageAnimation;
    [SerializeField] private AnimationReferenceAsset _idle;
   

    private void Start()
    {
        _skeletonGraphic.AnimationState.Event += HandleEvent;
        _skeletonGraphic.AnimationState.Complete += OnComplete ;
    }

    private void OnComplete(TrackEntry trackEntry)
    {
        PlayAnimation(_idle, true, 1f);
        AttackCompleted?.Invoke();
    }

    private void HandleEvent(TrackEntry trackEntry, Spine.Event e)
    {
        if (e.Data.Name == "Hit")
        {
            Debug.Log("Damage_anim");
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
        _health -= damage;
        ChangeHealth?.Invoke(_health);
        PlayAnimation(_damageAnimation, false, 1f);
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

    private void ResetStatus()
    {
        _isWalked = false;
    }

    public void SetStatus()
    {
        _isWalked = true;
    }

    public void Attack(Abillity abillity, Person person)
    {
        PlayAnimation(abillity.AnimationReferenceAsset, false, 1f);
        person.TakeDamage(abillity.Damage);
        SpendStamina(abillity.UseStamina);
    }

    private void PlayAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        _skeletonGraphic.AnimationState.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }


}
