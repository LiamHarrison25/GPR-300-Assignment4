using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGizmos : MonoBehaviour
{
    [SerializeField] private float sphereSize;
    [SerializeField] private Transform otherSphere;
    [SerializeField] private Color color;

    [SerializeField] private bool enableGizmos = true;
    [SerializeField] private bool drawLine = true;
    
    private void OnDrawGizmos()
    {
        if (enableGizmos)
        {
            Gizmos.color = color;
            Gizmos.DrawSphere(this.transform.position, sphereSize);
            if (drawLine)
            {
                Gizmos.DrawLine(this.transform.position, otherSphere.position);
            }
        }
    }
}
