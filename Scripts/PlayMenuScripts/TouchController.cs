using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private CallGameOvers gameOvers;
    private GameObject counter, backroundParent;
    private const int timeDestroy = 30;
   
    
    private void Start()
    {
        gameOvers = GameObject.FindAnyObjectByType<CallGameOvers>();
        counter = GameObject.FindGameObjectWithTag("counter");
        backroundParent = GameObject.FindGameObjectWithTag("playGround");
    }
    public void PopBall ()
    {
        counter.GetComponent<PointCounter>().PlusCount();
        BallClick();
        gameObject.SetActive(false);
    }
    
    private async void  BallClick ()
    {
       var explode = Instantiate(explosion, transform.position, Quaternion.identity, backroundParent.transform);
        explode.transform.localScale = transform.localScale;
        await Task.Delay(timeDestroy);
        Destroy(explode);
        Destroy(gameObject);
    }

    public void TrapClick ()
    {
        gameOvers.CallBadEnd();
    }

}
