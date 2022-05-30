using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : State
{
    [SerializeField] private RandomSideSelection _randomSideSelection;

    protected override void OnEnable()
    {
        _randomSideSelection.Reset();
        Cursor.visible = true;
        enabled = false;
    }
}
