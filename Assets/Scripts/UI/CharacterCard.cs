using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterCard : MonoBehaviour
{
    public event UnityAction<Person> ChoosedPerson;

    [SerializeField] private Person _character;
    private ChooseCharacter _personPlace;
    private Person _choosedPerson;
    private HeathBar _healthBar;
    private StaminaBar _staminaBar;


    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HeathBar>();
        _staminaBar = GetComponentInChildren<StaminaBar>();
        _personPlace = GetComponentInChildren<ChooseCharacter>();
        _personPlace.Choose += OnChoose;
    }

    private void OnDisable()
    {
        _personPlace.Choose += OnChoose;
    }

    private void Start()
    {
        if(_character != null)
            Init();
    }

    public void Init()
    {
        Person person =  Instantiate(_character, _personPlace.transform);
        _personPlace.SetPerson(person);
        _healthBar.Init(person);
        _staminaBar.Init(person);
        person.Init();
        person.Abillities[0].Use(); // Времянка
    }

    private void OnChoose(Person person)
    {
        _choosedPerson = person;
        ChoosedPerson?.Invoke(_choosedPerson);
    }
}
