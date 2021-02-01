using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class ShowSliderPercent : MonoBehaviour
{
    public Slider slider;
    public bool asInt = true;
    private TMP_Text text;

    private float maxSliderDistance;
    private float sliderPercent;
    // Shows a slider percent
    void Start()
    {
        text = GetComponent<TMP_Text>();
        if (slider == null) Debug.LogWarning("This object needs a slider attached", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null && slider != null)
        {
            maxSliderDistance = slider.maxValue;
            sliderPercent = (slider.value / maxSliderDistance)*100f;
            if(asInt) text.text = Mathf.CeilToInt(sliderPercent).ToString() + "%";
            else      text.text = sliderPercent.ToString() + "%";
        }
    }

}
