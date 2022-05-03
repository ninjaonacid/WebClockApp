using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkRequest : MonoBehaviour
{

    public static NetworkRequest Instance;

    readonly string timeServer1 = "http://worldtimeapi.org/api/ip";
    readonly string timeServer2 = "http://www.google.com/";
    private float timerForRequest = 60f;
    private DateTime _currentDateTime = DateTime.Now;
    public class TimeData
    {
        public string datetime;
    }

    private void Update()
    {
        timerForRequest -= Time.deltaTime / 60;
        if(timerForRequest <= 0)
        {
            RequestTimeFromServer(LoadDateFromServer(timeServer1));
            RequestTimeFromServer(LoadDataFromHeader(timeServer2));
            timerForRequest = 60f;
        }
        
    }
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);

        RequestTimeFromServer(LoadDateFromServer(timeServer1));
        RequestTimeFromServer(LoadDataFromHeader(timeServer2));
    }
   public DateTime GetCurrentDateTime() => 
    
       _currentDateTime.AddSeconds(Time.realtimeSinceStartup%60);

    private void RequestTimeFromServer(IEnumerator loadData)
    {
        StartCoroutine(loadData);
    }

   IEnumerator LoadDateFromServer(string url)
    {
        
        UnityWebRequest timeRequest = UnityWebRequest.Get(url);
        yield return timeRequest.SendWebRequest();

        if(timeRequest.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log("Error");
            
        } else
        {
            TimeData time = JsonUtility.FromJson<TimeData>(timeRequest.downloadHandler.text);
            _currentDateTime = DateTime.Parse(time.datetime);
        }

    }

    IEnumerator LoadDataFromHeader(string url)
    {
        UnityWebRequest timeRequest = UnityWebRequest.Get(url);
        yield return timeRequest.SendWebRequest();

        if (timeRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error");

        }
        else
        {
            string headerTime = timeRequest.GetResponseHeader("date");
            DateTime parsedTime = DateTime.ParseExact(headerTime,
                            "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                            CultureInfo.InvariantCulture.DateTimeFormat,
                            DateTimeStyles.AssumeUniversal);
            _currentDateTime = parsedTime;
        }

        
    }

    
   
}
