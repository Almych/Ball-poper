using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawner : MonoBehaviour
{
    [SerializeField] private TimerFlow timer;
    [SerializeField] private GameObject[] ballsTypes;
    [SerializeField] private GameObject trap;
    [SerializeField] private Transform minPosition, maxPosition;
    private int amountOfBalls = 0;
    private const int maxAmountBalls = 5;
    private const int minAmountBalls = 1;

    private int ballType = 0;
    private const float perFrame = 1.5f;
    private float xPostion = 0f;

    private const int minScale = 1;
    private const int maxScale = 4;
    private int currScale = 0;

    private int trapPercent;
    private const int minPercentTrap = 0;
    private const int maxPercentTrap = 10;
    
    private void Start()
    {
        BallsParameters();
        StartCoroutine(PlayBalls());
    }

    private IEnumerator PlayBalls ()
    {
        while(!timer.timerOver)
        {
            SpawnBalls(amountOfBalls, ballType);
            SpawnTraps();
            yield return new WaitForSeconds(perFrame);   
        }
    }
    
    private void BallsParameters () {
        amountOfBalls = Random.Range(minAmountBalls, maxAmountBalls);
        ballType = Random.Range(0, ballsTypes.Length);
        xPostion = Random.Range(minPosition.position.x, maxPosition.position.x);
        currScale = Random.Range(minScale, maxScale);
    }

    private void SpawnBalls (int amount, int ballType)
    {
        for (int i = 0; i < amount; i++)
        {
           var balls = Instantiate(ballsTypes[ballType], new Vector2(xPostion, minPosition.position.y), Quaternion.identity, transform);
            BallsParameters();
            balls.transform.localScale = new Vector2(currScale, currScale);
            ItemsForceUp(balls);
        }
        
    }

    private void SpawnTraps ()
    {
        
        trapPercent = Random.Range(minPercentTrap, maxPercentTrap);
        if (trapPercent <= 2)
        {
           var traps = Instantiate(trap, new Vector2(xPostion, minPosition.position.y), Quaternion.identity, transform);
            ItemsForceUp(traps);
        }
    }
    
    private void ItemsForceUp (GameObject item)
    {
        item.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000) * 20f);
    }

}
