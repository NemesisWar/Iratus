using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShadowPanel : MonoBehaviour
{
    [SerializeField] protected float MinAlphaChanell;
    [SerializeField] protected float MaxAlphaChanell;
    private ShadowCanvas _shadowCanvas;

    private void OnValidate()
    {
        if (MaxAlphaChanell == 0f || MaxAlphaChanell>1)
        {
            MaxAlphaChanell = 1f;
        }
    }

    private void Awake()
    {
        _shadowCanvas = GetComponentInParent<ShadowCanvas>();
    }

    private void OnEnable()
    {
        _shadowCanvas = GetComponentInParent<ShadowCanvas>();
        _shadowCanvas.StartBattle += MinAlpha;
        _shadowCanvas.EndBattle+=MaxAlpha;
    }

    private void OnDisable()
    {
        _shadowCanvas.StartBattle -= MinAlpha;
        _shadowCanvas.EndBattle -= MaxAlpha;
    }

    private void Start()
    {
        GetColorComponent();
    }

    protected abstract void GetColorComponent();

    protected abstract void MinAlpha();

    protected abstract void MaxAlpha();
}
