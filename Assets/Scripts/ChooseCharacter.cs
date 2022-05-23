using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseCharacter : MonoBehaviour, IPointerClickHandler
{
    public event UnityAction<Person> Choose;
    private Person _person;

    public void SetPerson(Person person) { _person = person; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Choose?.Invoke(_person);
    }
}
