using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSideSelection : MonoBehaviour
{
    private PlayerPanel _playerPanel;
    private EnemyPanel _enemyPanel;
    [SerializeField] private bool _playerAttack;
    [SerializeField] private CharacterCard _attacker;
    [SerializeField] private CharacterCard _defender;
    [SerializeField] private Abillity _abillity;
    private List<CharacterCard> _cards = new List<CharacterCard>();
    [SerializeField] private ChooseAbilities _chooseAbilities;
    [SerializeField] private GamePlayStateMachine _gamePlayStateMachine;
    [SerializeField] private ShadowCanvas _shadowCanvas;
    

    private void Awake()
    {
        _playerPanel = GetComponentInChildren<PlayerPanel>();
        _enemyPanel = GetComponentInChildren<EnemyPanel>();
        _cards.AddRange(_enemyPanel.GetComponentsInChildren<CharacterCard>());
    }

    private void OnEnable()
    {
        foreach (CharacterCard card in _cards)
        {
            card.ChooseCard += OnChooseEnemyCard;
        }
    }

    private void Start()
    {
        StartCoroutine(Testing());
    }

    private void OnDisable()
    {
        foreach (CharacterCard card in _cards)
        {
            card.ChooseCard -= OnChooseEnemyCard;
        }

        foreach (AbillityCard abilityCard in _chooseAbilities.AbillityCards)
        {
            abilityCard.ChoosenAbility -= OnChooseAbillity;
        }
    }
    public void Reset()
    {
        _attacker = null;
        _defender = null;
        _abillity = null;
        _shadowCanvas.BrightWindows();
        StartCoroutine(Testing());
    }

    private IEnumerator Testing()
    {
        yield return new WaitForSeconds(1f);
        ChooseSide();
        _chooseAbilities = GetComponentInChildren<ChooseAbilities>(); //Времянка
        foreach (AbillityCard abilityCard in _chooseAbilities.AbillityCards)
        {

            abilityCard.ChoosenAbility += OnChooseAbillity;
        }
    }


    private void ChooseSide()
    {
        //int number = Random.Range(1, 3);
        //if (number == 1)
        //{
        //    _playerAttack = false;
        //}

        //else if (number == 2)
        //{
        //    _playerAttack = true;
        //}

        ChoosePerson();
    }

    private void ChoosePerson()
    {
        if(_playerAttack == true)
        {
            int personNumber = Random.Range(0, _playerPanel.CharactersInList());
            _attacker = _playerPanel.GetCard(personNumber);
            _attacker.OnChoose();
            return;
        }

        if(_playerAttack == false)
        {
            int personNumber = Random.Range(0, _enemyPanel.CharactersInList());
            _attacker = _enemyPanel.GetCard(personNumber);
            ChooseAIAbillity();
        }
    }

    private void ChooseAIAbillity()
    {
        List<Abillity> abillities = new List<Abillity>();
        foreach (var ability in _attacker.PersonInThisCell.Abillities)
        {
            if(_attacker.PersonInThisCell.Stamina>=ability.UseStamina)
                abillities.Add(ability);
        }
        int abillityNumber = Random.Range(0, abillities.Count);
        _abillity = abillities[abillityNumber];
        if (_abillity.IsBaf == true)
        {
            _defender = null;
        }
        else
        {
            int personNumber = Random.Range(0, _playerPanel.CharactersInList());
            _defender = _playerPanel.GetCard(personNumber);
        }
        TryToStartBattle();
    }

    private void OnChooseEnemyCard(CharacterCard card) 
    {
        _defender = card;
        TryToStartBattle();
    }

    private void OnChooseAbillity(Abillity abillity)
    {
        _abillity = abillity;
        TryToStartBattle();
    }

    private void TryToStartBattle()
    {
        if(_attacker != null && _defender!=null && _abillity != null)
        {
            _gamePlayStateMachine.Init(_attacker, _defender, _abillity);
            _shadowCanvas.ShadowWindows(_attacker.PersonInThisCell, _defender.PersonInThisCell);
        }

        if(_attacker!=null && _abillity.IsBaf == true)
        {
            _gamePlayStateMachine.Init(_attacker, null, _abillity);
            _shadowCanvas.ShadowWindows(_attacker.PersonInThisCell, null);
        }
    }
}
