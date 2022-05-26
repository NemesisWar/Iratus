using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShadowCanvas : MonoBehaviour
{
    public event UnityAction StartBattle;

    public void ShadowWindows(Person attacker, Person defender)
    {
        attacker.gameObject.GetComponent<ShadowPanel>().enabled = false;
        defender.gameObject.GetComponent<ShadowPanel>().enabled = false;
        StartBattle?.Invoke();
        attacker.gameObject.GetComponent<ShadowPanel>().enabled = true;
        defender.gameObject.GetComponent<ShadowPanel>().enabled = true;
    }
}
