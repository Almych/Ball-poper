using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockFacts : MonoBehaviour
{
    [SerializeField] private GameObject nameUnlockFact;
    [SerializeField] private int unlockPoints;
    private MaxPointsSave max;

    private void Awake()
    {
        max = GameObject.FindAnyObjectByType<MaxPointsSave>();
    }
    public void CheckUnlock ()
    {
        Unlock();
    }

    private void Unlock ()
    {
        if (unlockPoints <= max.maxPoints)
        {
            nameUnlockFact.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }


}
