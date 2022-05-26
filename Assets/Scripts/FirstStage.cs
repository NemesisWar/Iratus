using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FirstStage : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransformFirstCharacter;
    [SerializeField] private RectTransform _rectTransformSecondCharacter;
    [SerializeField] private Abillity abillity;


    private void Start()
    {
        //_rectTransform1.DOAnchorPos(_rectTransform2.anchoredPosition, 2f);
        //_rectTransform2.DOAnchorPos(_rectTransform1.anchoredPosition, 2f);

        //person = card.GetComponentInChildren<Person>();
        //person2 = card2.GetComponentInChildren<Person>();
        //person.Abillities[0].Use(person2);
    }
}
