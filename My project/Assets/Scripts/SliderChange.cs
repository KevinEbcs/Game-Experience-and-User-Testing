using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;
    public TextMeshProUGUI minValue;
    public TextMeshProUGUI maxValue;
        
        // Start is called before the first frame update
    void Start()
    {
        minValue.text = slider.minValue.ToString("F");
        maxValue.text = slider.maxValue.ToString("F");
    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = slider.value.ToString("F");
    }
}
