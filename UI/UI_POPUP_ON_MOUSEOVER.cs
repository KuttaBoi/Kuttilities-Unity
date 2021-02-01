using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_POPUP_ON_MOUSEOVER : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float Amount = 1.5f;
    public float Speed = 1f;

    private Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= Amount;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = localScale;
    }

}
