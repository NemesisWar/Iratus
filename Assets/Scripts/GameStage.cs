using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStage : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    private ShadowCanvas _shadowCanvas;
    private FighterChoose _fighterChoose;

    private void Awake()
    {
        _shadowCanvas = _canvas.GetComponent<ShadowCanvas>();
        _fighterChoose = _canvas.GetComponentInChildren<FighterChoose>();
    }

    private void OnEnable()
    {
        _fighterChoose.StartFight += OnStartFight;
    }
    private void OnDisable()
    {
        _fighterChoose.StartFight -= OnStartFight;
    }

    private void OnStartFight(Person attaker, Person defender, Abillity abillity)
    {

    }
}
