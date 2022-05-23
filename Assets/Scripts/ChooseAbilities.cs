using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAbilities : MonoBehaviour
{
    [SerializeField] private FighterChoose _fighterChoose;
    private List<ChooseCharacter> _chooseCharacters = new List<ChooseCharacter> ();
    private List<AbillityCard> _abillityCards = new List<AbillityCard> ();

    private void Awake()
    {
        _chooseCharacters.AddRange(_fighterChoose.GetComponentsInChildren<ChooseCharacter>());
        _abillityCards.AddRange(GetComponentsInChildren<AbillityCard>());
    }

    private void Start()
    {
        HideAllAbillityCard();
    }

    private void OnEnable()
    {
        foreach (var character in _chooseCharacters)
        {
            character.Choose += ShowAllAbilities;
        }
    }

    private void OnDisable()
    {
        foreach (var character in _chooseCharacters)
        {
            character.Choose -= ShowAllAbilities;
        }
    }

    private void HideAllAbillityCard()
    {
        foreach (var card in _abillityCards)
        {
            card.gameObject.SetActive(false);
        }
    }

    private void ShowAllAbilities(Person person)
    {
        HideAllAbillityCard();
        List<Abillity> abilities = new List<Abillity>();
        abilities = person.Abillities;
        for (int i = 0; i < abilities.Count; i++)
        {
            _abillityCards[i].gameObject.SetActive(true);
            _abillityCards[i].Init(abilities[i]);
        }
    }
}
