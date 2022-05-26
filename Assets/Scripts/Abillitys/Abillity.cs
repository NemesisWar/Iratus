using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Abillity : MonoBehaviour
{
    public Sprite Sprite => _sprite;
    public string Name => _name;
    public bool IsBaf => _isBaff;
    public int Damage => _damage;
    public int UseStamina => _useStamina;
    public AnimationReferenceAsset AnimationReferenceAsset => _animationReferenceAsset;
    [SerializeField] private AnimationReferenceAsset _animationReferenceAsset;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private bool _isBaff;
    [SerializeField] private int _useStamina;
    [SerializeField] private int _damage;
    [SerializeField] private SkeletonGraphic SkeletonGraphic;
    private Person _person;

}
