using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPanel : MonoBehaviour
{
    private List<CharacterCard> _characterCards = new List<CharacterCard>();
    private List<CharacterCard> _charactersInTurnQueue = new List<CharacterCard>();

    private void Awake()
    {
        _characterCards.AddRange(GetComponentsInChildren<CharacterCard>());
    }

    public void ResetWent()
    {
        foreach (var character in _characterCards)
        {
            character.ResetStatus();
        }
    }

    public bool EveryoneWent()
    {
        UpdateCharInTirnQueue();
        return _charactersInTurnQueue.Count == 0;
    }

    public CharacterCard GetDefenderCard()
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
        return _characterCards[Random.Range(0, _characterCards.Count)];
    }

    public void UpdateCharInTirnQueue()
    {
        List<CharacterCard> list = new List<CharacterCard>();
        foreach (CharacterCard card in _characterCards)
        {
            if (card.gameObject.activeSelf == true && card.IsWalkied == false)
            {
                list.Add(card);
            }
        }
        _charactersInTurnQueue = list;
    }

    public CharacterCard GetRandomAttackerCard()
    {
        UpdateCharInTirnQueue();
        return _charactersInTurnQueue[Random.Range(0, _charactersInTurnQueue.Count)];
    }
}
