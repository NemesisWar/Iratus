using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShadowCanvas : MonoBehaviour
{
    public event UnityAction StartBattle;
    public event UnityAction EndBattle;

    public void ShadowWindows(Person attacker, Person defender)
    {
        CheckPersons(attacker, defender, false);
        StartBattle?.Invoke();
        CheckPersons(attacker, defender, true);
    }

    private void CheckPersons(Person attacker, Person defender, bool setStatus)
    {
        if(attacker != null && defender != null)
        {
            attacker.gameObject.GetComponent<ShadowPanel>().enabled = setStatus;
            defender.gameObject.GetComponent<ShadowPanel>().enabled = setStatus;
        }
    }

    public void BrightWindows()
    {
        EndBattle?.Invoke();
    }
}
