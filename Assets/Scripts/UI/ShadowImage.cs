using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowImage : ShadowPanel
{
    private Image _image;

    protected override void MinAlpha()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, MinAlphaChanell);
    }

    protected override void GetColorComponent()
    {
        _image = GetComponent<Image>();
    }

    protected override void MaxAlpha()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, MaxAlphaChanell);
    }
}
