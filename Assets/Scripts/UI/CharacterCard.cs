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
    public bool IsWalkied => _isWalked;
    public Person PersonInThisCell => _personInThisCell;
    [SerializeField] private Person _character;
    [SerializeField] private GameObject _container;
    [SerializeField] private bool _isEnemy;
    private Person _personInThisCell;
    private HeathBar _healthBar;
    private StaminaBar _staminaBar;
    private IndicatorChoosedPlayer _indicatorChoosedPlayer;
    private bool _isWalked;


    private void OnEnable()
    {
        _healthBar = GetComponentInChildren<HeathBar>();
        _staminaBar = GetComponentInChildren<StaminaBar>();
        _indicatorChoosedPlayer = GetComponentInChildren<IndicatorChoosedPlayer>();
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
        //_indicatorChoosedPlayer.Init(this);
    }

    public void OnChoose()
    {
        _indicatorChoosedPlayer.gameObject.SetActive(true);
        _isWalked = true;
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

    public void ResetStatus()
    {
        _isWalked = false;
    }
}
