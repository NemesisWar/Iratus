using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSideSelection : MonoBehaviour
{
    [SerializeField] private PlayerPanel _playerPanel;
    [SerializeField] private EnemyPanel _enemyPanel;
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
        _cards.AddRange(_enemyPanel.GetComponentsInChildren<CharacterCard>());
        //_chooseAbilities = GetComponentInChildren<ChooseAbilities>();
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

    private IEnumerator Testing()
    {
        yield return new WaitForSeconds(0.1f);
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
        int abillityNumber = Random.Range(0, _attacker.PersonInThisCell.Abillities.Count);
        _abillity = _attacker.PersonInThisCell.Abillities[abillityNumber];
        if (_abillity.IsBaf == true)
        {
            _defender = null;
        }
        else
        {
            int personNumber = Random.Range(0, _playerPanel.CharactersInList());
            _defender = _playerPanel.GetCard(personNumber);
        }
        
    }

    private void OnChooseEnemyCard(CharacterCard card) 
    {
        _defender = card;
        _gamePlayStateMachine.Init(_attacker, _defender, _abillity);
        _shadowCanvas.ShadowWindows(_attacker.PersonInThisCell,_defender.PersonInThisCell);
    }

    private void OnChooseAbillity(Abillity abillity)
    {
        _abillity = abillity;
    }
}
