using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CallGameOvers : MonoBehaviour
{
    [SerializeField] private GameObject goodEnd, badEnd;
    [SerializeField] private TextMeshProUGUI totalPointsGoodOver, totalPointsBadOver;
    private GameObject points;
    private MaxPointsSave maxPointsSave;

    private void Start()
    {
        points = GameObject.FindGameObjectWithTag("counter");
        maxPointsSave = GameObject.FindAnyObjectByType<MaxPointsSave>();
    }

    public void CallGoodEnd ()
    {
        maxPointsSave.SavePoints(points.GetComponent<PointCounter>().totalPoints);
        totalPointsGoodOver.text = points.GetComponent<TextMeshProUGUI>().text;
        goodEnd.SetActive(true);
    }

    public void CallBadEnd()
    {
        maxPointsSave.SavePoints(points.GetComponent<PointCounter>().totalPoints);
        totalPointsBadOver.text = points.GetComponent<TextMeshProUGUI>().text;
        Time.timeScale = 0;
        badEnd.SetActive(true);
    }
}
