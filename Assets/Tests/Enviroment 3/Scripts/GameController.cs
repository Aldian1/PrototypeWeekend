using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [SerializeField]
    private Text[] uiPlaceholder;
    //1 target count, 2 missed count, 3 accuracy
    private int targetCount;

    private int missPoint;

    private int hitPoint;
    protected GameController() { }
    // Use this for initialization
    void Start()
    {
        UpdateScore();
    }
    public void HitSkeet()
    {
        hitPoint++;
        UpdateScore();
    }
    public void AddAPoint()
    {
        targetCount++;
        UpdateScore();
    }
    public void MinusAPoint()
    {
        missPoint--;
        UpdateScore();
    }

    private void UpdateScore()
    {
        uiPlaceholder[0].text = targetCount.ToString();
        uiPlaceholder[1].text = missPoint.ToString();
        uiPlaceholder[2].text = hitPoint.ToString();
    }
}
