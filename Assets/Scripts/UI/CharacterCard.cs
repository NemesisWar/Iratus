using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterCard : MonoBehaviour
{
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> StaminaChanged;

}
