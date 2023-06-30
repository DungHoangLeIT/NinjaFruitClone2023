using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSlider(int maxHeath)
    {
        slider.value = maxHeath;
        slider.maxValue = maxHeath;
    }

    public void SetSlider(int heath)
    {
        slider.value = heath;   
    }
}
