using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpBar : MonoBehaviour
{
    Slider slider;

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
