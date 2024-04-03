using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernstein : MonoBehaviour
{
    [SerializeField] private Transform p0;
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    [SerializeField] private Transform p3;
    [SerializeField] private Transform P;
    private Vector3 PoVector;
    private Vector3 P1Vector;
    private Vector3 P2Vector;
    private Vector3 P3Vector;
    
    [SerializeField] private float T = 0f;
    [SerializeField] private int curvePrecision = 100;

    [SerializeField] private bool drawGizmosEnabled = false;
    
   
    private Vector3 [] curvePointsArray;
    
    private void Awake()
    {
        curvePointsArray = new Vector3[curvePrecision];
        drawGizmosEnabled = true;
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
        CalculateCurve();
        //Step();
    }

    private void CalculatePoint(float t, int index)
    {
        PoVector = p0.position - P.position;
        P1Vector = p1.position - P.position;
        P2Vector = p2.position - P.position;
        P3Vector = p3.position - P.position;

        Vector3 p0Equation = p0.position * (-(Mathf.Pow(t, 3)) + 3 * Mathf.Pow(t, 2) - 3 * t + 1);
        Vector3 p1Equation = p1.position * (3 * Mathf.Pow(t, 3) - 6 * Mathf.Pow(t, 2) + 3 * t);
        Vector3 p2Equation = p2.position * (-3 * Mathf.Pow(t, 3) + 3 * Mathf.Pow(t, 2) );
        Vector3 p3Equation = p3.position * (Mathf.Pow(t, 3));
        P.position = p0Equation + p1Equation + p2Equation + p3Equation;

        curvePointsArray[index] = P.position;

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
