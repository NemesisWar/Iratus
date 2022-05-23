using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FighterChoose : MonoBehaviour
{
    public event UnityAction<Person, Person, Abillity> StartFight;

    private PlayerPanel _playerPanel;
    private EnemyPanel _enemyPanel;
    private ChooseAbilities _chooseAbilities;

    private List<ChooseCharacter> _characters = new List<ChooseCharacter>();  
    private List<AbillityCard> _abillities = new List<AbillityCard>();

    [SerializeField]private List<Person> _rivals = new List<Person>();
    [SerializeField]private Abillity _abillity;

    private void Awake()
    {
        _playerPanel = GetComponentInChildren<PlayerPanel>();
        _enemyPanel = GetComponentInChildren<EnemyPanel>();
        _chooseAbilities = GetComponentInChildren<ChooseAbilities>();
    }

    private void OnEnable()
    {
        _characters.AddRange(_playerPanel.GetComponentsInChildren<ChooseCharacter>());
        _characters.AddRange(_enemyPanel.GetComponentsInChildren<ChooseCharacter>());
        _abillities.AddRange(_chooseAbilities.GetComponentsInChildren<AbillityCard>());

        foreach (var player in _characters)
        {
            player.Choose += SetRival;
        }

        foreach (var abillityCard in _abillities)
        {
            abillityCard.ChoosenAbility += SetAbillity;
        }
    }

    private void SetRival(Person person) 
    {
        _rivals.Add(person);
    }

    private void SetAbillity(Abillity abillity) 
    {
        _abillity = abillity;
    }

    private void ClearAll()
    {
        _rivals.Clear();
        _abillity = null;
    }

    private void Check()
    {
        if(_rivals.Count == 2 && _abillity != null)
        {
            StartFight?.Invoke(_rivals[0], _rivals[1], _abillity);
        }

    }
}
