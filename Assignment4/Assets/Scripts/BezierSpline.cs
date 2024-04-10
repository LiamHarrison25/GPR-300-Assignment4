using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierSpline : MonoBehaviour
{
    [SerializeField] private int numIntervals;
    [SerializeField] private float u; //Parameter space
    [SerializeField] private int numSections;

    [SerializeField] private Casteljau[] splineSections;
    
    [SerializeField] private int curvePrecision = 400;
    
    private void CalculateCurve()
    {
        float step = 1.0f / curvePrecision;
        int i;
        for (i = 0; i < curvePrecision; i++)
        {
            //splineSections[Mathf.FloorToInt(u)].CalculatePoint(Mathf.Clamp01(u), i);
            //T += step;
        }

        //T = 0;
    }
    
    
    //TODO: Combine the control points for the attached joins.knots so that there are 2 control points rather than 4
    //TODO: Mirror the control points for the attached joins/Knots

    private void Awake()
    {
        
    }
}
