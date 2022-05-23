using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class ShadowSceleton : ShadowPanel
{
    private SkeletonGraphic _skeletonGraphic;

    protected override void ChangeAlpha()
    {
        _skeletonGraphic.color = new Color(_skeletonGraphic.color.r, _skeletonGraphic.color.g, _skeletonGraphic.color.b, MinAlpha);
    }

    protected override void GetColorComponent()
    {
        _skeletonGraphic = GetComponent<SkeletonGraphic>();
    }
}
