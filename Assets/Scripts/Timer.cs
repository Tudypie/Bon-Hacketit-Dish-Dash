using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float startingTime;
    private float currentTime;

    [SerializeField] private TMP_Text timerText;

    [Space]
    [SerializeField] private UnityEvent onTimerEnd;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            onTimerEnd.Invoke();
            enabled = false;
        }
    }
}
