using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityFigmaBridge.Runtime.UI;

public class TimerFlow : MonoBehaviour
{
    public bool timerOver;
    [SerializeField] private TextMeshProUGUI timerUi;
    [SerializeField] private GameObject speedUpEffect, speedNormalEffect;
    [SerializeField] private CallGameOvers gameOvers;
    private float timer = 60f;
    private const float perFrame = 0.000001f;
    

    private void Start()
    {
        timerOver = false;
        StartCoroutine(TimerFlowing());
    }

    private IEnumerator TimerFlowing ()
    {
        while (timer > 0f)
        {
            SpeedUp();
            yield return new WaitForSeconds(perFrame);
            timer -= Time.deltaTime;
            updateTimer(timer);
        }
        timerOver = true;
        gameOvers.CallGoodEnd();
    }


    private void updateTimer (float currTimer)
    {
        currTimer += 1;
        float minutes = Mathf.FloorToInt(currTimer / 60);
        float seconds = Mathf.FloorToInt(currTimer % 60);
       timerUi.text = string.Format("{0} : {1:00}", minutes, seconds);
    }

    private void SpeedUp ()
    {
        if (timer < 30)
        {
            speedUpEffect.SetActive(true);
            speedNormalEffect.SetActive(false);
        }
        else
        {
            speedUpEffect.SetActive(false);
            speedNormalEffect.SetActive(true);
        }
    }
   
}
