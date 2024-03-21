using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer sr;
    public Color start;
    public Color end;
    float interpolation;
    public void SliderValueHasChanged(float value)
    {
        interpolation = value/60;
    }
    public void DropDownHasChanged(int value)
    {
        Debug.Log(dropdown.options[value].text);
    }

    private void Update()
    {
        sr.color = Color.Lerp(start, end, interpolation);
    }
}
