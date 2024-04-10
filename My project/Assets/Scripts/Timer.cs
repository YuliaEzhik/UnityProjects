using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f;
    private float timeLeft;
    private int sec = 0;
    private int min = 0;
    private TMP_Text _TimerText;
    [SerializeField] private int delta = 0;

    private void Start()
    {
        _TimerText = GameObject.Find("TimerText").GetComponent<TMP_Text>();
        StartCoroutine(ITimer());
        timeLeft = totalTime;
    }

    IEnumerator ITimer()
    {
        while(true)
        {
            if(sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            _TimerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
