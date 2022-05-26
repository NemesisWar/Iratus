using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CharacterCard : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<CharacterCard> ChooseCard;
    public event UnityAction<Person> ChoosedPerson;
    [SerializeField] public Person PersonInThisCell => _personInThisCell;
    [SerializeField] private Person _character;
    [SerializeField] private GameObject _container;
    private Person _personInThisCell;
    private HeathBar _healthBar;
    private StaminaBar _staminaBar;


    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HeathBar>();
        _staminaBar = GetComponentInChildren<StaminaBar>();
    }


    private void Start()
    {
        if(_character != null)
            Init();
    }

    public void Init()
    {
        _personInThisCell =  Instantiate(_character, _container.transform);
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
}
