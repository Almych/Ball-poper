using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoaderController : MonoBehaviour
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Sprite[] loaderStates;
    private int lastIndexOfState = 0;
    private const float timeLoading = 1f;
    private int index = 0;
    private void Start()
    {
        lastIndexOfState = loaderStates.GetUpperBound(0);
        StartCoroutine(LoadingLoader());
    }

    private IEnumerator LoadingLoader ()
    {
        while(transform.GetComponent<Image>().sprite != loaderStates[lastIndexOfState])
        {
            yield return new WaitForSeconds(timeLoading);
            transform.GetComponent<Image>().sprite = loaderStates[index];
            index = (index < loaderStates.Length) ? index + 1 : 0;
        }
        mainMenu.NextScene();
    }
}
