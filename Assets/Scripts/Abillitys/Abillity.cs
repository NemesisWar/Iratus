using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Abillity : MonoBehaviour
{
    [SerializeField] private AnimationReferenceAsset _animationReferenceAsset;
    [SerializeField] private Image _image;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _isBaff;
    [SerializeField] private int _useStamina;
    [SerializeField] private int _damage;
    private SkeletonGraphic SkeletonGraphic;
    private Person _person;

    private void Start()
    {
        SkeletonGraphic = GetComponent<SkeletonGraphic>();
        _person = GetComponent<Person>(); 
    }

    public void Use(Person enemy)
    {
        PlayAnimation(_animationReferenceAsset, false, 1f);
        enemy.TakeDamage(_damage);
        _person.SpendStamina(_useStamina);
    }

    private void PlayAnimation(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        SkeletonGraphic.AnimationState.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }
}
