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
    

    [SerializeField] private float T = .5f;


    private void CalculatePoint()
    {
        A.position = Vector3.Lerp(p0.position, p1.position, T);
        B.position = Vector3.Lerp(p1.position, p2.position, T);
        C.position = Vector3.Lerp(p2.position, p3.position, T);
        D.position = Vector3.Lerp(A.position, B.position, T);
        E.position = Vector3.Lerp(B.position, C.position, T);
        P.position = Vector3.Lerp(D.position, E.position, T);
    }

    private void Update()
    {
        CalculatePoint();
    }
}
