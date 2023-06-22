using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;
    public int points;

    private void Awake()
    {
        instance = this;
    }


    public void addPoints(int pointValue)
    {
        points += pointValue;
    }



}
