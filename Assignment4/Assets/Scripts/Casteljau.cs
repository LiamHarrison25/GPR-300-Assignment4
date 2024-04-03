using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Casteljau : MonoBehaviour
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    [SerializeField] private Transform A;
    [SerializeField] private Transform B;
    [SerializeField] private Transform C;
    [SerializeField] private Transform D;
    [SerializeField] private Transform E;
    [SerializeField] private Transform P;
    
    //TODO: Make a way to add points and have C1 continuous
    //TODO: Rotate the object to face tangent to the spline
    //TODO: Animate an object to move along the spline by changing the T value

    [SerializeField] private float T = 0f;
    [SerializeField] private int curvePrecision = 100;

    [SerializeField] private bool drawGizmosEnabled = false;
    [SerializeField] private int stepThroughAmount = 1;
    [SerializeField] private bool enableStepThrough = false;
    
   
    private Vector3 [] curvePointsArray;
    
    //For stepping through making the curve
    private float theStep;
    private int theIndex;

    private void Awake()
    {
        curvePointsArray = new Vector3[curvePrecision];
        drawGizmosEnabled = true;
        
    }


    private void CalculatePoint(float t, int index)
    {
        A.position = Vector3.Lerp(p0.position, p1.position, t);
        B.position = Vector3.Lerp(p1.position, p2.position, t);
        C.position = Vector3.Lerp(p2.position, p3.position, t);
        D.position = Vector3.Lerp(A.position, B.position, t);
        E.position = Vector3.Lerp(B.position, C.position, t);
        P.position = Vector3.Lerp(D.position, E.position, t);

        curvePointsArray[index] = P.position;

    }

    private void CalculateCurve()
    {
        float step = 1.0f / curvePrecision;
        int i;
        for (i = 0; i < curvePrecision; i++)
        {
            CalculatePoint(T, i);
            T += step;
        }

        T = 0;
    }

    private void Update()
    {
        if (stepThroughAmount > curvePrecision || stepThroughAmount < 0)
        {
            Debug.LogError("Please make sure that stepThroughAmount is a valid value");
        }
        
        if (enableStepThrough)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Step();
            }
        }
        else
        {
            CalculateCurve();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            enableStepThrough = !enableStepThrough;
        }
       
    }

    private void Start()
    {
        theStep = 1.0f / curvePrecision;
        theIndex = 0;
    }

    private void Step()
    {
        if (theIndex < curvePrecision)
        {
            int i;
            //while(i )
            //for (theIndex; i < stepThroughAmount; i++)
            //{
                Debug.Log("step " + theIndex);
                CalculatePoint(T, theIndex);
                T += theStep;
            //}
        }
        else
        {
            theIndex = 0;
            T = 0;
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmosEnabled)
        {
            Gizmos.color = Color.green;
            Vector3 previousPoint = curvePointsArray[0];
            int i;
            for(i = 1; i < curvePrecision; i++)
            {
                Gizmos.DrawLine(curvePointsArray[i], previousPoint);
                previousPoint = curvePointsArray[i];
            }
        }
    }
}
