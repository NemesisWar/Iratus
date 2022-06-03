using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{
    private List<IndicatorChoosedPlayer> _indicatorChoosedPlayers = new List<IndicatorChoosedPlayer>();

    private void Awake()
    {
        _indicatorChoosedPlayers.AddRange(GetComponentsInChildren<IndicatorChoosedPlayer>());
    }

    public void Reset()
    {
        foreach (var indicator in _indicatorChoosedPlayers)
        {
            indicator.gameObject.SetActive(false);
        }
    }
}
