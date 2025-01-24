using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainTime;
    [SerializeField] private AudioClip timeIsUp;

    // Update is called once per frame
    void Update()
    {
        if (remainTime <= 0)
        {
            remainTime = 0;
            Time.timeScale = 0;
            SoundManager.instance.PlaySound(timeIsUp);
        }
        else if (remainTime > 0)
            remainTime -= Time.deltaTime;

        int minutes = Mathf.FloorToInt(remainTime / 60);
        int seconds = Mathf.FloorToInt(remainTime % 60);



        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
