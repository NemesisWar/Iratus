using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Spine.Unity;

public class CharacterCard : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<CharacterCard> ChooseCard;
    public event UnityAction<Person> ChoosedPerson;
    public bool IsEnemy => _isEnemy;
    [SerializeField] public Person PersonInThisCell => _personInThisCell;
    [SerializeField] private Person _character;
    [SerializeField] private GameObject _container;
    [SerializeField] private bool _isEnemy;
    private Person _personInThisCell;
    private HeathBar _healthBar;
    private StaminaBar _staminaBar;


    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HeathBar>();
        _staminaBar = GetComponentInChildren<StaminaBar>();
    }

    private void OnDisable()
    {
        if (_personInThisCell != null) 
        {
            _personInThisCell.Die -= OnDie;
        }
    }


    private void Start()
    {
        if (_character != null)
            Init();
        else
            gameObject.SetActive(false);
    }

    public void Init()
    {
        _character.GetComponent<SkeletonGraphic>().initialFlipX = _isEnemy;
        _personInThisCell =  Instantiate(_character, _container.transform);
        _personInThisCell.Die += OnDie;
        _healthBar.Init(_personInThisCell);
        _staminaBar.Init(_personInThisCell);
    }

    public void OnChoose()
    {
        ChoosedPerson?.Invoke(_personInThisCell);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseCard?.Invoke(this);
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
    }
}
