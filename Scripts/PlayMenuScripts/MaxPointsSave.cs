using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MaxPointsSave : MonoBehaviour
{
   
   public int maxPoints;
   [SerializeField] private static MaxPointsSave save;

    private void Awake()
    {
        
        if (save == null)
        {
            save = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SavePoints (int points)
    {
        if (points > maxPoints)
        {
            maxPoints = points;
        }
    }
}
