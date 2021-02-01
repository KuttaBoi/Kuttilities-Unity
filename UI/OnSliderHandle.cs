using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Slider))]
public class OnSliderHandle : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent<float> SendSliderInput;
    public UnityEvent OnDragTrigger;
    public UnityEvent OnStartDragTrigger;
    public UnityEvent OnEndDragTrigger;

    private Slider slider;
    private float percentSliderValue = 0;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        percentSliderValue = (slider.value / slider.maxValue);
    }

    public void SetSliderValuePercentage(float f)
    {
        f = Mathf.Clamp01(f);
        slider.value = (f * slider.value);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(OnStartDragTrigger!=null) OnStartDragTrigger.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (SendSliderInput != null) SendSliderInput.Invoke(percentSliderValue);
        if (OnDragTrigger != null) OnDragTrigger.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragTrigger != null) OnEndDragTrigger.Invoke();
    }
}
