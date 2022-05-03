using System;
using UnityEngine;


public class ClockLogic : MonoBehaviour
{
    [SerializeField] private Transform _hourArrow;
    [SerializeField] private Transform _minuteArrow;
    [SerializeField] private Transform _secondArrow;
    [SerializeField] private DisplayTime _timer;

    private DateTime time = DateTime.Now;
    float seconds = 0;
    float minutes = 0;
    float hours = 0;


    void Update()
    {

        time = NetworkRequest.Instance.GetCurrentDateTime();
        seconds = time.Second;
        minutes = time.Minute;
        hours = time.Hour;
 
        _hourArrow.eulerAngles = new Vector3(0f, 0f, 360f / 12f * -hours);
        _minuteArrow.eulerAngles = new Vector3(0f, 0f, 360f / 60f * -minutes);
        _secondArrow.eulerAngles = new Vector3(0f, 0f, 360f / 60f * -seconds);

    }

}
