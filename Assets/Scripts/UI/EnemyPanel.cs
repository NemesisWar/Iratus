using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPanel : MonoBehaviour
{
    [SerializeField] private List<CharacterCard> _characterCards = new List<CharacterCard>();
    private bool _allCompletedActivities;

    private void Awake()
    {
        _characterCards.AddRange(GetComponentsInChildren<CharacterCard>());
    }

    private void UpdateList()
    {
        List<CharacterCard> list = new List<CharacterCard>();
        foreach (CharacterCard card in _characterCards)
        {
            if (card.gameObject.activeSelf == true)
            {
                list.Add(card);
            }
        }
        _characterCards = list;
    }

    public int CharactersInList()
    {
        UpdateList();
        return _characterCards.Count;
    }

    public CharacterCard GetCard(int numberCharacter)
    {
        //SetActivityMarkOnPerson(_characterCards[numberCharacter]);
        return _characterCards[numberCharacter];
    }

    //private void SetActivityMarkOnPerson(CharacterCard activityCard)
    //{
    //    activityCard.PersonInThisCell.SetStatus();
    //}

    public CharacterCard TakeCard(int numberCharacter)
    {
        return _characterCards[numberCharacter];
    }
}
