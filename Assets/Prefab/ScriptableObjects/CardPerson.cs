using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Person", menuName = "Card/Create New Card", order = 51)]
public class CardPerson : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _gameObject;
}
