using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityFigmaBridge.Runtime.UI;

public class TurnOnOffController : MonoBehaviour
{
    public Color turnOn;
    public Color turnOff;
    private FigmaImage figmaImage;


    private void Start()
    {
        figmaImage = GetComponent<FigmaImage>();
    }

    public void TurnOn()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        figmaImage.StrokeColor = turnOn;
    }

    public void TurnOff()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        figmaImage.StrokeColor = turnOff;
    }
}
