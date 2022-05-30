using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ShadowSceleton : ShadowPanel
{
    private SkeletonGraphic _skeletonGraphic;

    protected override void MinAlpha()
    {
        _skeletonGraphic.color = new Color(_skeletonGraphic.color.r, _skeletonGraphic.color.g, _skeletonGraphic.color.b, MinAlphaChanell);
    }

    protected override void GetColorComponent()
    {
        _skeletonGraphic = GetComponent<SkeletonGraphic>();
    }

    protected override void MaxAlpha()
    {
        _skeletonGraphic.color = new Color(_skeletonGraphic.color.r, _skeletonGraphic.color.g, _skeletonGraphic.color.b, MaxAlphaChanell);
    }
}
