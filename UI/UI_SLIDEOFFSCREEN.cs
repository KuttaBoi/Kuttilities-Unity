using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//Move the atached canvas out off screen with a button, leaving anotehr in its place
public class UI_SLIDEOFFSCREEN : MonoBehaviour
{
    [SerializeField]
    Button HIDE_BUTTON;
    [SerializeField]
    Button SHOW_BUTTON;
    [SerializeField]
    RectTransform canvas;
    void Start()
    {
        HIDE_BUTTON.onClick.AddListener(HIDE);
        SHOW_BUTTON.onClick.AddListener(SHOW);

    }
    public void HIDE()
    {
        float width = canvas.sizeDelta.x;
        Vector3 targetPosition = new Vector3(-width, canvas.position.y, 0);
        canvas.DOMove(targetPosition, 1f, false);
        HIDE_BUTTON.gameObject.SetActive(false);
        SHOW_BUTTON.gameObject.SetActive(true);
    }
    public void SHOW()
    {
        Vector3 targetPosition = new Vector3(0, canvas.position.y, 0);
        canvas.DOMove(targetPosition, 1f, false);
        HIDE_BUTTON.gameObject.SetActive(true);
        SHOW_BUTTON.gameObject.SetActive(false);
    }
}
