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

    [HideInInspector] public int currentHour;
    bool nowPM;
    int curthing = 1;

    float currentTime;

    private void Start()
    {
        currentHour = startHour;
        hourText.text = startHour.ToString() + "AM";
        GetComponent<FailState>().hourNow = currentHour;
    }
    private void Update()
    {
        currentTime += Time.deltaTime;
        // Debug.Log((int)currentTime + " " + (int)currentTime / secondsPerHour);
        if ((int)currentTime / secondsPerHour == curthing && (int)currentTime != 0)
        {
            GetComponent<FailState>().hourNow = currentHour;
            currentHour++;
            curthing++;
            if (nowPM)
            {
                if (currentHour == 12)
                {
                    hourText.text = currentHour.ToString();
                }
                else
                {
                    hourText.text = (currentHour - 12).ToString();
                }
                hourText.text += "PM";
            }
            else
            {
                hourText.text = currentHour.ToString();
                hourText.text += "AM";
            }
            if (currentHour == 11)
            {
                nowPM = true;
            }
        }

        if (currentHour >= endHour)
        {
            GetComponent<FailState>().Fail();
        }
    }
}
