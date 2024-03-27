using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGizmos : MonoBehaviour
{
    [SerializeField] private float sphereSize;
    [SerializeField] private Transform otherSphere;
    [SerializeField] private Color color;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(this.transform.position, sphereSize);
        Gizmos.DrawLine(this.transform.position, otherSphere.position);
    }
}
