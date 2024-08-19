using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public int totalPoints = 0; 
    private TextMeshProUGUI pointUi;
    private int points = 0;
   
    private void Start()
    {
        pointUi = GetComponent<TextMeshProUGUI>();
    }
    public void PlusCount ()
    {
        totalPoints += 1;
        pointUi.text = (points += 1).ToString();

    }
}
