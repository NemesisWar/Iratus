using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightersPool : MonoBehaviour
{
    [SerializeField] private List <CardPerson> _playerPersons;
    [SerializeField] private List <CardPerson> _enemyPersons;
    [SerializeField] private FighterChoose _fighterChoose;


    private void OnEnable()
    {
        
    }
}
