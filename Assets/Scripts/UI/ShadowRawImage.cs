using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowRawImage : ShadowPanel
{
    private RawImage _rawImage;

    protected override void ChangeAlpha()
    {
        _rawImage.color = new Color(_rawImage.color.r, _rawImage.color.g, _rawImage.color.b, MinAlpha);
    }

    protected override void GetColorComponent()
    {
        _rawImage = GetComponent<RawImage>(); 
    }
}
