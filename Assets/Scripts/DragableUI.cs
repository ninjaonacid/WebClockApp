using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isDragging;

    void Update()
    {
        if(isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0f, 0f, angle);


        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
