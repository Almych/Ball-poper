using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactsUpdate : MonoBehaviour
{
    [SerializeField] private UnlockFacts[] facts;


    public void UpdateFacts ()
    {
        foreach(var fact in facts)
        {
            fact.CheckUnlock();
        }
    }
}
