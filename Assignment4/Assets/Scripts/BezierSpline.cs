using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSpline : MonoBehaviour
{
    [SerializeField] private int numIntervals;
    [SerializeField] private float u; //Parameter space

    [SerializeField] private Casteljau[] splineSections;
    
    //TODO: Combine the control points for the attached joins.knots so that there are 2 control points rather than 4
    //TODO: Mirror the control points for the attached joins/Knots

    private void Awake()
    {
        
    }
}
