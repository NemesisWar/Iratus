using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ShadowCanvas : MonoBehaviour
{
    public event UnityAction StartBattle;

    private void Start()
    {

    }

    private void ShadowWindows()
    {
        StartBattle?.Invoke();
    }
}
