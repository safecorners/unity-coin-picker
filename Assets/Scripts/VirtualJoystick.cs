using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Image imageBackground;
    private Image imageController;

    public Vector2 touchPosition;

    void Awake()
    {
        imageBackground = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnDrag(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imageBackground.rectTransform, eventData.position,
            eventData.pressEventCamera,
            out touchPosition))
        {
            // nomalize touchPosition [0, 1]
            touchPosition.x = (touchPosition.x / imageBackground.rectTransform.sizeDelta.x);
            touchPosition.y = (touchPosition.y / imageBackground.rectTransform.sizeDelta.y);

            // pivot [0, 1] -> [-n, n]
            touchPosition.x = (imageBackground.rectTransform.pivot.x == 1) ? touchPosition.x * 2 + 1 : touchPosition.x * 2 - 1;
            touchPosition.y = (imageBackground.rectTransform.pivot.y == 1) ? touchPosition.y * 2 + 1 : touchPosition.y * 2 - 1;

            // nomalize [-n, n] -> [-1, 1]
            touchPosition = (touchPosition.magnitude > 1) ? touchPosition.normalized : touchPosition;

            Debug.Log(touchPosition);

            moveImageController(touchPosition);
        }
    }

    private void moveImageController(Vector2 touchPosition)
    {
        imageController.rectTransform.anchoredPosition = new Vector2(
            touchPosition.x * (imageBackground.rectTransform.sizeDelta.x / 2),
            touchPosition.y * (imageBackground.rectTransform.sizeDelta.y / 2)
        );
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        imageController.rectTransform.anchoredPosition = Vector2.zero;
        touchPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return touchPosition.x;
    }

    public float Vertical()
    {
        return touchPosition.y;
    }
}

