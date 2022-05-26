using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAbilities : MonoBehaviour
{
    public List<AbillityCard> AbillityCards => _abillityCards;
    [SerializeField] private GameObject _mainPanel;
    private List<CharacterCard> _characters = new List<CharacterCard> ();
    private List<AbillityCard> _abillityCards = new List<AbillityCard> ();

    private void Awake()
    {
        _characters.AddRange(_mainPanel.GetComponentsInChildren<CharacterCard>());
        _abillityCards.AddRange(GetComponentsInChildren<AbillityCard>());
    }

    private void OnEnable()
    {
        foreach (var character in _characters)
        {
            character.ChoosedPerson += ShowAllAbilities;
        }
    }

    private void Start()
    {
        HideAllAbillityCard();
    }

    private void OnDisable()
    {
        foreach (var character in _characters)
        {
            character.ChoosedPerson -= ShowAllAbilities;
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
