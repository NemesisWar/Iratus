using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShadowPanel : MonoBehaviour
{
    [SerializeField] protected float MinAlpha;
    private ShadowCanvas _shadowCanvas;

    private void Awake()
    {
        _shadowCanvas = GetComponentInParent<ShadowCanvas>();
    }

    private void OnEnable()
    {
        _shadowCanvas = GetComponentInParent<ShadowCanvas>();
        _shadowCanvas.StartBattle += ChangeAlpha;
    }

    private void OnDisable()
    {
        _shadowCanvas.StartBattle -= ChangeAlpha;
    }

    private void Start()
    {
        GetColorComponent();
    }

    protected abstract void GetColorComponent();
    //if (GetComponent<Image>())
    //    _color = GetComponent<Image>().color;
    //if (GetComponent<RawImage>())
    //    _color = GetComponent<RawImage>().color;
    //if(GetComponent<SkeletonGraphic>())
    //_color = GetComponent<SkeletonGraphic>().color;

    protected abstract void ChangeAlpha();
}
