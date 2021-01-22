using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StrainBar : MonoBehaviour
{
    public Slider slider;

    public void SetStrain(int strain)
    {
        slider.value = strain;
    }

    public void SetMaxStrain(int strain)
    {
        slider.maxValue = strain;
        slider.value = strain;
    }
}
