using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    Slider slider;
    private void OnEnable()
    {
        EventSys.PickCrystal += RefreshExpBar;
    }
    private void OnDisable()
    {
        EventSys.PickCrystal -= RefreshExpBar;
    }
    // Use this for initialization
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.value = 0;

    }


    public void RefreshExpBar(float percent)
    {
        slider.value = percent;
    }

}
