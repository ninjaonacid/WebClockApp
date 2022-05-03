using System;
using UnityEngine;


public class ClockLogic : MonoBehaviour
{
    [SerializeField] private Transform _hourArrow;
    [SerializeField] private Transform _minuteArrow;
    [SerializeField] private Transform _secondArrow;
    [SerializeField] private DisplayTime _timer;

    float seconds = 0;
    float minutes = 0;
    float hours = 0;
    private bool isDragging;
    private DateTime time = DateTime.Now;

    void Update()
    {

        time = NetworkRequest.Instance.GetCurrentDateTime();
        seconds = time.Second;
        minutes = time.Minute;
        hours = time.Hour;
 
        _hourArrow.eulerAngles = new Vector3(0f, 0f, 360f / 12f * -hours);
        _minuteArrow.eulerAngles = new Vector3(0f, 0f, 360f / 60f * -minutes);
        _secondArrow.eulerAngles = new Vector3(0f, 0f, 360f / 60f * -seconds);

        if(Input.GetMouseButtonDown(0))
        {
           Vector3 startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
        }
    }

}
