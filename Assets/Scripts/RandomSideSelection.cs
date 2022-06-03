using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomSideSelection : MonoBehaviour
{
    [SerializeField] private PlayerPanel _playerPanel;
    [SerializeField] private PlayerPanel _enemyPanel;
    [SerializeField] private GamePlayStateMachine _gamePlayStateMachine;
    [SerializeField] private ShadowCanvas _shadowCanvas;
    private bool _playerAttack;
    private CharacterCard _attacker;
    private CharacterCard _defender;
    private Abillity _abillity;
    private List<CharacterCard> _cards = new List<CharacterCard>();
    private ChooseAbilities _chooseAbilities;
    private IndicatorManager _indicatorManager;

    private void Awake()
    {
        _cards.AddRange(_enemyPanel.GetComponentsInChildren<CharacterCard>());
        _indicatorManager = GetComponent<IndicatorManager>();
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
        StartCoroutine(StartRound());
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
        StartCoroutine(StartRound());
    }

    private IEnumerator StartRound()
    {
        yield return new WaitForEndOfFrame();
        _indicatorManager.Reset();
        ChooseSide();
        _chooseAbilities = GetComponentInChildren<ChooseAbilities>();
        foreach (AbillityCard abilityCard in _chooseAbilities.AbillityCards)
        {

            abilityCard.ChoosenAbility += OnChooseAbillity;
        }
    }


    private void ChooseSide()
    {
        if (_playerPanel.EveryoneWent() == true)
            _playerAttack = false;
        if (_enemyPanel.EveryoneWent() == true)
            _playerAttack = true;

        if(_playerPanel.EveryoneWent() == false && _enemyPanel.EveryoneWent() == false)
        {
            int number = Random.Range(1, 3);
            if (number == 1)
            {
                _playerAttack = false;
            }

            else if (number == 2)
            {
                _playerAttack = true;
            }
        }
        if (_playerPanel.EveryoneWent() == true && _enemyPanel.EveryoneWent() == true)
        {
            _playerPanel.ResetWent();
            _enemyPanel.ResetWent();
        }
        ChoosePerson();
    }

    private void ChoosePerson()
    {
        if(_playerAttack == true)
        {
            _attacker = _playerPanel.GetRandomAttackerCard();
            _attacker.OnChoose();
            _playerPanel.UpdateCharInTirnQueue();
            return;
        }

        if(_playerAttack == false)
        {
            _attacker = _enemyPanel.GetRandomAttackerCard();
            _attacker.OnChoose();
            _enemyPanel.UpdateCharInTirnQueue();
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
            _defender = _playerPanel.GetDefenderCard();
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
