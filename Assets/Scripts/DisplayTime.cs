using UnityEngine;
using UnityEngine.UI;


public class DisplayTime : MonoBehaviour
{
    public Text timeDisplay;

    private void Awake()
    {
        timeDisplay = transform.GetComponent<Text>();
    }

    private void Update()
    {
       timeDisplay.text = NetworkRequest.Instance.GetCurrentDateTime()
            .ToString("HH:mm:ss");

       if(Input.GetMouseButtonDown(0) && Input.touchCount > 0)
        {

        }
       
    }

}
