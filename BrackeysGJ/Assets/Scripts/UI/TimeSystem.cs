using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] int secondsPerHour = 30;
    [SerializeField] int startHour = 8;
    [SerializeField] int endHour;
    [SerializeField] TextMeshProUGUI hourText;

    int currentHour;
    bool nowPM;
    int curthing = 1;

    private void Start()
    {
        currentHour = startHour;
        hourText.text = startHour.ToString() + "AM";
    }
    private void Update()
    {
        // Debug.Log((int)Time.time + " " + (int)Time.time / secondsPerHour);
        if ((int)Time.time / secondsPerHour == curthing && (int)Time.time != 0)
        {
            currentHour++;
            curthing++;
            hourText.text = currentHour.ToString();
            if (nowPM)
            {
                hourText.text += "PM";
            }
            else
            {
                hourText.text += "AM";
            }
            if (currentHour == 12)
            {
                nowPM = true;
            }
        }
    }
}
